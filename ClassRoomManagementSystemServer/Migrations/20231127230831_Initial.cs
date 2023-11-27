using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoomManagementSystemServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    department_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    building_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    num_classroom = table.Column<uint>(type: "int unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.department_name);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "time_slot",
                columns: table => new
                {
                    time_slot_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    day = table.Column<DateOnly>(type: "date", nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.time_slot_id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "classroom",
                columns: table => new
                {
                    classroom_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    room_num = table.Column<int>(type: "int", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    blackout_hours = table.Column<TimeOnly>(type: "time", nullable: true),
                    Department_department_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.classroom_id);
                    table.ForeignKey(
                        name: "fk_Classroom_Department1",
                        column: x => x.Department_department_name,
                        principalTable: "department",
                        principalColumn: "department_name");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    course_title = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    credits = table.Column<float>(type: "float", nullable: true),
                    Department_department_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.course_title);
                    table.ForeignKey(
                        name: "fk_Course_Department1",
                        column: x => x.Department_department_name,
                        principalTable: "department",
                        principalColumn: "department_name");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "request",
                columns: table => new
                {
                    request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Department_department_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Classroom_classroom_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.request_id);
                    table.ForeignKey(
                        name: "fk_Request_Classroom1",
                        column: x => x.Classroom_classroom_id,
                        principalTable: "classroom",
                        principalColumn: "classroom_id");
                    table.ForeignKey(
                        name: "fk_Request_Department",
                        column: x => x.Department_department_name,
                        principalTable: "department",
                        principalColumn: "department_name");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "equipment",
                columns: table => new
                {
                    equipment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    equipment_type = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Classroom_classroom_id = table.Column<int>(type: "int", nullable: false),
                    Course_course_title = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.equipment_id);
                    table.ForeignKey(
                        name: "fk_Equipment_Classroom1",
                        column: x => x.Classroom_classroom_id,
                        principalTable: "classroom",
                        principalColumn: "classroom_id");
                    table.ForeignKey(
                        name: "fk_Equipment_Course1",
                        column: x => x.Course_course_title,
                        principalTable: "course",
                        principalColumn: "course_title");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "section",
                columns: table => new
                {
                    section_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    course_title = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    year = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    semester = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Course_course_title = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Time_Slot_time_slot_id = table.Column<int>(type: "int", nullable: false),
                    Classroom_classroom_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.section_id, x.course_title, x.semester, x.year, x.Course_course_title })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0 });
                    table.ForeignKey(
                        name: "fk_Section_Classroom1",
                        column: x => x.Classroom_classroom_id,
                        principalTable: "classroom",
                        principalColumn: "classroom_id");
                    table.ForeignKey(
                        name: "fk_Section_Course1",
                        column: x => x.Course_course_title,
                        principalTable: "course",
                        principalColumn: "course_title");
                    table.ForeignKey(
                        name: "fk_Section_Time_Slot1",
                        column: x => x.Time_Slot_time_slot_id,
                        principalTable: "time_slot",
                        principalColumn: "time_slot_id");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "fk_Classroom_Department1_idx",
                table: "classroom",
                column: "Department_department_name");

            migrationBuilder.CreateIndex(
                name: "fk_Course_Department1_idx",
                table: "course",
                column: "Department_department_name");

            migrationBuilder.CreateIndex(
                name: "fk_Equipment_Classroom1_idx",
                table: "equipment",
                column: "Classroom_classroom_id");

            migrationBuilder.CreateIndex(
                name: "fk_Equipment_Course1_idx",
                table: "equipment",
                column: "Course_course_title");

            migrationBuilder.CreateIndex(
                name: "fk_Request_Classroom1_idx",
                table: "request",
                column: "Classroom_classroom_id");

            migrationBuilder.CreateIndex(
                name: "fk_Request_Department_idx",
                table: "request",
                column: "Department_department_name");

            migrationBuilder.CreateIndex(
                name: "fk_Section_Classroom1_idx",
                table: "section",
                column: "Classroom_classroom_id");

            migrationBuilder.CreateIndex(
                name: "fk_Section_Course1_idx",
                table: "section",
                column: "Course_course_title");

            migrationBuilder.CreateIndex(
                name: "fk_Section_Time_Slot1_idx",
                table: "section",
                column: "Time_Slot_time_slot_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipment");

            migrationBuilder.DropTable(
                name: "request");

            migrationBuilder.DropTable(
                name: "section");

            migrationBuilder.DropTable(
                name: "classroom");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "time_slot");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
