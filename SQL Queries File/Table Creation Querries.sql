CREATE SCHEMA IF NOT EXISTS;
USE mydb;

CREATE TABLE IF NOT EXISTS Department (
    department_name VARCHAR(45) NOT NULL,
    building_name VARCHAR(45) NOT NULL,
    num_classroom INT UNSIGNED NULL,
    PRIMARY KEY (department_name)
);

CREATE TABLE IF NOT EXISTS Classroom (
    classroom_id INT NOT NULL AUTO_INCREMENT,
    room_num INT NOT NULL,
    capacity INT NOT NULL,
    blackout_hours TIME NULL,
    department_name VARCHAR(45) NOT NULL,
    PRIMARY KEY (classroom_id),
    INDEX fk_Classroom_Department1_idx (department_name),
    CONSTRAINT fk_Classroom_Department1
        FOREIGN KEY (department_name)
        REFERENCES Department (department_name)
);

CREATE TABLE IF NOT EXISTS Request (
    request_id INT NOT NULL AUTO_INCREMENT,
    description TEXT NOT NULL,
    department_name VARCHAR(45) NOT NULL,
    classroom_id INT NOT NULL,
    PRIMARY KEY (request_id),
    INDEX fk_Request_Department_idx (department_name),
    INDEX fk_Request_Classroom1_idx (classroom_id),
    CONSTRAINT fk_Request_Department
        FOREIGN KEY (department_name)
        REFERENCES Department (department_name),
    CONSTRAINT fk_Request_Classroom1
        FOREIGN KEY (classroom_id)
        REFERENCES Classroom (classroom_id)
);

CREATE TABLE IF NOT EXISTS Course (
    course_title VARCHAR(10) NOT NULL,
    credits FLOAT NULL,
    department_name VARCHAR(45) NOT NULL,
    PRIMARY KEY (course_title),
    INDEX fk_Course_Department1_idx (department_name),
    CONSTRAINT fk_Course_Department1
        FOREIGN KEY (department_name)
        REFERENCES Department (department_name)
);

CREATE TABLE IF NOT EXISTS Time_Slot (
    time_slot_id INT NOT NULL AUTO_INCREMENT,
    day DATE NOT NULL,
    start_time TIME NOT NULL,
    end_time TIME NOT NULL,
    PRIMARY KEY (time_slot_id)
);

CREATE TABLE IF NOT EXISTS Section (
    section_id INT NOT NULL AUTO_INCREMENT,
    course_title VARCHAR(45) NOT NULL,
    year VARCHAR(45) NOT NULL,
    semester VARCHAR(45) NOT NULL,
    Course_course_title VARCHAR(10) NOT NULL,
    Time_Slot_time_slot_id INT NOT NULL,
    Classroom_classroom_id INT NOT NULL,
    PRIMARY KEY (section_id, course_title, semester, year, course_title),
    INDEX fk_Section_Course1_idx (Course_course_title),
    INDEX fk_Section_Time_Slot1_idx (time_slot_id),
    INDEX fk_Section_Classroom1_idx (classroom_id),
    CONSTRAINT fk_Section_Course1
        FOREIGN KEY (course_title)
        REFERENCES Course (course_title),
    CONSTRAINT fk_Section_Time_Slot1
        FOREIGN KEY (time_slot_id)
        REFERENCES Time_Slot (time_slot_id),
    CONSTRAINT fk_Section_Classroom1
        FOREIGN KEY (classroom_id)
        REFERENCES Classroom (classroom_id)
);

CREATE TABLE IF NOT EXISTS Equipment (
    equipment_id INT NOT NULL AUTO_INCREMENT,
    equipment_type VARCHAR(45) NOT NULL,
    classroom_id INT NOT NULL,
    course_title VARCHAR(10) NOT NULL,
    PRIMARY KEY (equipment_id),
    INDEX fk_Equipment_Classroom1_idx (classroom_id),
    INDEX fk_Equipment_Course1_idx (course_title),
    CONSTRAINT fk_Equipment_Classroom1
        FOREIGN KEY (classroom_id)
        REFERENCES Classroom (classroom_id),
    CONSTRAINT fk_Equipment_Course1
        FOREIGN KEY (course_title)
        REFERENCES Course (course_title)
);
