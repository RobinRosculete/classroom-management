# Classroom Management Project

## Table of Contents

- [Project Description](#project-description)
- [Conceptual Design](#conceptual-design)
- [Logical Database Design](#logical-database-design)
- [System Design](#system-design)
- [Deployment](#deployment)
- [Development Documentation](#development-documentation)
- [Database Implementation](#database-implementation)
- [Stored Procedures](#stored-procedures)
- [User Manual](#user-manual)

## Project Description

Upon receiving a request from our stakeholder, we developed a database system to enhance the management of their class offerings. This system efficiently processes and archives all requests within a centralized database, allowing users to assign, modify, and oversee classroom allocations for their courses effortlessly. Moreover, the class management system has been constructed on a client/server model to ensure a more streamlined user experience.

## Conceptual Design

### Entity-Relationship (ER) Diagram

The entity-relationship (ER) diagram is a visual representation of the data model for our project. It outlines the structure of the database and the interrelations among its entities. Each entity represents a type of object within the system, and each relationship represents an association between these objects. Relationships are crucial for a relational database as they define how data in one table is related to data in another, allowing for complex queries and reports.

![ER Diagram](https://github.com/RobinRosculete/classroom-management/blob/main/Readme%20Images/er-diagram.png)
_Figure 1: Classroom Management ER Diagram_

## Logical Database Design

The logical diagram details our project's relational database schema, focusing on logical relationships between different entities and their attributes. It specifies primary keys (PK) and foreign keys (FK), crucial for maintaining database integrity and consistency.

![Relational Schema](https://github.com/RobinRosculete/classroom-management/blob/main/Readme%20Images/logical-design.png)
_Figure 2: Classroom Management Relational Schema_

## System Design

Our classroom management system uses the Model View Controller (MVC) architecture:

- **View:** Renders the User Interface for the Department Secretary.
- **Model:** Maps the database entities and handles requests and responses.
- **Controller:** Manages HTTP requests from the view and applies system logic.

![Architecture Design](https://github.com/RobinRosculete/classroom-management/blob/main/Readme%20Images/system-design.png)
_Figure 3: Architecture Design Pattern_
## Deployment

The application was deployed using Azure App Service and Azure Database for MySQL. The View server was hosted separately from the ASP.NET server, allowing users to access the system from various locations.
![Deployment Diagram](https://github.com/RobinRosculete/classroom-management/blob/main/Readme%20Images/deployment-diagram.png)
_Figure 4: Classroom Management Deployment_

## Development Documentation

### Development Environment and Target Platforms

- **MySQL Workbench:** Database management
- **Visual Studio:** ASP.NET development
- **Visual Studio Code:** Angular development

### Capabilities and Interface

- **Request Management:** Automatically handles classroom assignments and conflicts.
- **Room Assignment Reports:** Displays details of each room assignment.
- **Classroom Properties:** Allows viewing and updating of blackout hours and equipment.

## Database Implementation

### MySQL Workbench

- Run queries for database creation.
- Write and test procedures before server implementation.
- Update the database as the design evolves.

### ASP.NET Migrations

- Update the database from the ASP.NET server.

### Entities

1. **Equipment:** Identifies equipment and links to classrooms and courses.
2. **Classroom:** Represents physical classrooms with attributes like room number, capacity, and blackout hours.
3. **Course:** Holds course information, including title, credits, and department.
4. **Requests:** Represents requests made by the department, linked to classrooms and sections.
5. **Section:** Details course sections, linked to courses, time slots, and classrooms.
6. **Time Slot:** Contains scheduling information with day and start/end times.
7. **Department:** Represents institution departments with attributes like name, building, and number of classrooms.

## Stored Procedures

- **PerformSectionAndRequestAssignment:** Main procedure that calls others to handle requests and assignments.
- **InsertTimeSlot:** Collects time slot data and returns an ID.
- **InsertRequest:** Collects request data and returns a section ID.
- **InsertSection:** Links department name to the section ID.
- **FindAvailableClassroom:** Finds an available classroom for a section.
- **GetSectionDetails:** Retrieves section details for classroom assignment.
- **FindAvailableClassroomInDifferentDept:** Finds a classroom in a different department if none are available.

## User Manual

- **Video Demo:** [video demo](https://www.loom.com/share/4dd5ffbc227242ad8b1ff09744391446?sid=f1fc58aa-665d-4eb4-8800-7fd86d38cdc4).

### How to Use

Navigate the application using the navigation bar at the top of the page. Below are the main functionalities provided by the application:

### Submit Classroom Requests Page

- **Purpose:** Request a classroom.
- **Instructions:**
  1. Enter the following details:
     - Day
     - Start Time
     - End Time
     - Course Title
     - Year
     - Semester
     - Department Name
  2. Submit the form to request a classroom.

### View Room Assignments Page

- **Purpose:** View all rooms that have been reserved by request.
- **Instructions:** Navigate to this page to see a list of all classroom reservations.

### Modify Requests Page

- **Purpose:** Update your classroom requests.
- **Instructions:**
  1. Select the request you want to update.
  2. Modify the details as needed.
  3. Submit the updated request.

### View Room Properties Page

- **Purpose:** View blackout hours and available equipment of the rooms.
- **Instructions:** Navigate to this page to see detailed information about each room, including any blackout hours when the room is unavailable and the equipment available in the room.

### Update Room Properties Page

- **Purpose:** Update classroom blackout hours and equipment.
- **Instructions:**
  1. Select the room you want to update.
  2. Modify the blackout hours or update the equipment details.
  3. Save the changes.




