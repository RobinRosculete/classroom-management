DELIMITER //

CREATE PROCEDURE PerformSectionAndRequestAssignment(
IN sectionDay VARCHAR(3), IN sectionStartTime TIME , 
IN sectionEndTime TIME, IN sectionCoursetitle VARCHAR(20),
IN sectionYear YEAR, IN sectionSemester VARCHAR(20),
IN courseDepartment VARCHAR(30)
)
BEGIN
-- Call InsertTimeSlot procedure and retrieve the last inserted time_slot_id
CALL InsertTimeSlot(sectionDay, sectionStartTime, sectionEndTime);
SELECT @last_time_slot_id := LAST_INSERT_ID();

-- Call InsertSection procedure and pass the retrieved time_slot_id
CALL InsertSection(sectionCoursetitle, sectionYear, sectionSemester, @last_time_slot_id);
SELECT @last_section_id := LAST_INSERT_ID();

-- Call InsertRequest procedure and pass the retrieved section_id
CALL InsertRequest(courseDepartment, @last_section_id);

-- Call the AssignClassroomToSection procedure to assign the available classroom to the section
CALL AssignClassroomToSection(@last_section_id);

END //

DELIMITER ;


DELIMITER //
-- Procedure to retrieve section details
CREATE PROCEDURE GetSectionDetails(IN sectionID INT, OUT timeSlotID INT, OUT dayValue VARCHAR(10), OUT startTime TIME, OUT endTime TIME, OUT departmentName VARCHAR(30), OUT sectionYear YEAR, OUT sectionSemester VARCHAR(20), OUT sectionCourseTitle VARCHAR(20))
BEGIN
    -- Get section details
    SELECT TS.time_slot_id, TS.day, TS.start_time, TS.end_time, C.department_name, S.year, S.semester, S.course_title
    INTO timeSlotID, dayValue, startTime, endTime, departmentName, sectionYear, sectionSemester, sectionCourseTitle 
    FROM Section AS S
    INNER JOIN Time_Slot AS TS ON S.time_slot_id = TS.time_slot_id
    INNER JOIN Request AS R ON R.section_id = S.section_id
    INNER JOIN Course AS C ON C.course_title = S.course_title
    WHERE S.section_id = sectionID;
END //

DELIMITER //

-- Procedure to find an available classroom in a different department
CREATE PROCEDURE FindAvailableClassroomInDifferentDept(
    IN departmentName VARCHAR(30),
    IN dayValue VARCHAR(10),
    IN startTime TIME,
    IN endTime TIME,
    IN sectionID INT,
    OUT availableClassroomID INT,
    IN sectionSemester VARCHAR(20),
    IN sectionYear YEAR
)
BEGIN
    SELECT C.classroom_id INTO availableClassroomID
    FROM Classroom AS C
    JOIN Department AS D ON C.department_name = D.department_name
    WHERE D.department_name != departmentName
        AND C.classroom_id NOT IN (
            SELECT S1.classroom_id
            FROM Section AS S1
            INNER JOIN Time_Slot AS TS1 ON S1.time_slot_id = TS1.time_slot_id
            WHERE TS1.day = dayValue
	
                AND (
                    (startTime >= TS1.start_time AND startTime < TS1.end_time)
                    OR (endTime > TS1.start_time AND endTime <= TS1.end_time)
                    OR (startTime <= TS1.start_time AND endTime >= TS1.end_time)
                )
                AND S1.section_id != sectionID 
        )
        AND S1.year = sectionYear
		AND S1.semester = sectionSemester
    LIMIT 1;
END //

-- Main procedure for class assignment in the same department
CREATE PROCEDURE FindAvailableClassroom(
    IN sectionID INT,
    OUT availableClassroomID INT
)
BEGIN
    -- Variables to store section details
    DECLARE timeSlotID INT;
    DECLARE dayValue VARCHAR(10);
    DECLARE startTime TIME;
    DECLARE endTime TIME;
    DECLARE departmentName VARCHAR(30);
	DECLARE sectionSemester VARCHAR(20);
    DECLARE sectionYear YEAR;
    DECLARE sectionCourseTitle VARCHAR(20);

    CALL GetSectionDetails(sectionID, timeSlotID, dayValue, startTime, endTime, departmentName, sectionYear, sectionSemester, sectionCourseTitle);

    -- Find available classroom within the same department
    SELECT C.classroom_id INTO availableClassroomID
    FROM Classroom AS C
    JOIN Department AS D ON C.department_name = D.department_name
    WHERE D.department_name = departmentName
        AND C.classroom_id NOT IN (
            SELECT S1.classroom_id
            FROM Section AS S1
            INNER JOIN Time_Slot AS TS1 ON S1.time_slot_id = TS1.time_slot_id
            WHERE TS1.day = dayValue
                AND (
                    (startTime >= TS1.start_time AND startTime < TS1.end_time)
                    OR (endTime > TS1.start_time AND endTime <= TS1.end_time)
                    OR (startTime <= TS1.start_time AND endTime >= TS1.end_time)
                )
                AND S1.section_id != sectionID 
				AND S1.year = sectionYear
				AND S1.semester = sectionSemester
        )   
 
    
    LIMIT 1;
    -- If not available classroom found in the current department, call the other procedure
    IF availableClassroomID IS NULL THEN
        CALL FindAvailableClassroomInDifferentDept(departmentName, dayValue, startTime, endTime, sectionID, availableClassroomID,sectionSemester,sectionYear);
    END IF;
END //



-- Procedure to assign classroom to section
CREATE PROCEDURE AssignClassroomToSection(IN sectionID INT)
BEGIN
    DECLARE availableClassroomID INT;

    -- Find available classroom
    CALL FindAvailableClassroom(sectionID, availableClassroomID);

    IF availableClassroomID IS NOT NULL THEN
        -- Updating the  sectio with the available classroom
        UPDATE Section
        SET classroom_id = availableClassroomID
        WHERE section_id = sectionID;
        SELECT 'Classroom assigned successfully' AS Result;
	   
       -- Updating the Request with the new classroom
		UPDATE Request
        SET classroom_id = availableClassroomID
        WHERE section_id = sectionID;
    ELSE
        SELECT 'No available classroom found' AS Result;
    END IF;
END //

DELIMITER ;

DROP PROCEDURE IF EXISTS FindAvailableClassroom;
DROP PROCEDURE IF EXISTS AssignClassroomToSection;
DROP PROCEDURE IF EXISTS FindAvailableClassroomInDifferentDept;
DROP PROCEDURE IF EXISTS GetSectionDetails;
DROP PROCEDURE IF EXISTS PerformSectionAndRequestAssignment;

DELIMITER //
-- Insert Time-Slot
CREATE PROCEDURE InsertTimeSlot(
    IN day_value VARCHAR(10),
    IN start_time_value TIME,
    IN end_time_value TIME
)
BEGIN
    START TRANSACTION;

    -- Insert data into time_slot table
    INSERT INTO time_slot(day, start_time, end_time)
    VALUES (day_value, start_time_value, end_time_value);

    COMMIT;
END //
DELIMITER ;
DROP PROCEDURE InsertTimeSlot;

-- Insert Section
DELIMITER //
CREATE PROCEDURE InsertSection(
    IN course_title_value VARCHAR(20),
    IN year_value INT,
    IN semester_value VARCHAR(20),
    IN time_slot_id_val INT
)
BEGIN
    START TRANSACTION;

    -- Insert data into section table
    INSERT INTO section(course_title, year, semester, time_slot_id)
    VALUES (course_title_value, year_value, semester_value, time_slot_id_val);

    COMMIT;
END //
DELIMITER ;
DROP PROCEDURE InsertSection;

-- Insert Request
DELIMITER //
CREATE PROCEDURE InsertRequest(
    IN department_name_value VARCHAR(30),
    IN section_id_val INT
)
BEGIN
    START TRANSACTION;

    -- Insert data into Request table
    INSERT INTO request (department_name, section_id)
    VALUES (department_name_value, section_id_val);

    COMMIT;
END //
DELIMITER ;
DROP PROCEDURE InsertRequest;

-- DepartmentClassroomCount ClassroomCount
DELIMITER //
CREATE PROCEDURE DepartmentClassroomCount( IN department_name_value VARCHAR(30))
BEGIN
SELECT COUNT(*) 
FROM Classroom
WHERE department_name = department_name_value;
END//
DELIMITER ;
DROP PROCEDURE DepartmentClassroomCount;

-- Procedure to modify a Request Day and Time
DELIMITER //
CREATE PROCEDURE UpdateRequest( IN requestID INT, IN dayValue VARCHAR(10),
 IN startTime TIME, IN endTime TIME )
BEGIN
  DECLARE sectionID INT;
  DECLARE timeSlotID INT; 
  DECLARE classroomID INT; 
  
-- Getting the section ID
SELECT section_id INTO sectionID
FROM request
WHERE request_id = requestID ;

-- Geting the timeslot Id
SELECT time_slot_id INTO timeSlotID
FROM section
WHERE section_id = sectionID ; 

-- Updating time slot to new time slot
UPDATE time_slot
SET 
day = dayValue,
start_time = startTime,
end_time = endTime 
WHERE time_slot.time_slot_id = timeSlotID;
-- call Procedure to get new classroomID

 -- Find available classroom
    CALL FindAvailableClassroom(sectionID, classroomID);

-- need to update clasrrom id if order has conflict after
UPDATE section
SET 
classroom_id = classroomID
WHERE  section.section_id = sectionID;

-- Also Updating the request classroom
UPDATE request
SET 
classroom_id = classroomID
WHERE  request.section_id = sectionID;

END//

DROP PROCEDURE UpdateRequest;
DELIMITER ;

-- Procedure to update the classrooms 
DELIMITER //
CREATE PROCEDURE UpdateClassRoom( IN roomID INT,  IN equipmentID INT,IN EquipmentType VARCHAR(50),
 IN  blackoutHoursStart TIME,IN blackoutHoursEnd  TIME )
 BEGIN


 -- Query to update the BlackoutHours of clasrrom
 UPDATE classroom 
 SET 
 blackout_hours_start =blackoutHoursStart,
 blackout_hours_end =blackoutHoursEnd
 WHERE classroom_id = roomID;
 

 -- Query to update the Equipment of clasrrom
 UPDATE equipment
 SET 
	equipment_type = EquipmentType
	WHERE equipment_id = equipmentID;
 END //
 
DROP PROCEDURE UpdateClassRoom;
DELIMITER ;


































