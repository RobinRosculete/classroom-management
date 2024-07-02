SELECT * from equipment;
SELECT d.department_name
FROM Department d
JOIN Course c ON d.department_name = c.department_name
JOIN Equipment e ON c.course_title = e.course_title
WHERE e.equipment_type = 'computer'
GROUP BY d.department_name
HAVING COUNT(DISTINCT c.course_title) >= 2;
