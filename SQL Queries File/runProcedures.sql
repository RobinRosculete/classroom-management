
-- Calling Procedures to test Functionality before adding to server
CALL PerformSectionAndRequestAssignment('MW', '13:00:00', '14:00:00', 'ART202', 2023, 'Spring', 'Art');


CALL UpdateRequest(228,'MW','13:00:00', '14:00:00');

CALL UpdateClassRoom('1',  '37','Smart TV','23:00:00' ,'05:00:00');
    
UPDATE equipment SET equipment_type ="computer" WHERE equipment_id = 12;

UPDATE equipment SET course_title ="ART202" WHERE equipment_id = 10;
UPDATE equipment SET course_title ="ART322" WHERE equipment_id = 11;

SELECT * from equipment;

SELECT d.department_name
FROM Department d
JOIN Course c ON d.department_name = c.department_name
JOIN Equipment e ON c.course_title = e.course_title
WHERE e.equipment_type = 'computer'
GROUP BY d.department_name
HAVING COUNT(DISTINCT c.course_title) >= 2;







