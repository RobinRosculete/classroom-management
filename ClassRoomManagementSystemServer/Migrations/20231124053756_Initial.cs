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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    building_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    number_classrooms = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.building_name);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Time_Slot",
                columns: table => new
                {
                    time_slot_id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    day = table.Column<DateOnly>(type: "date", nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.time_slot_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    classroom_id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    room_number = table.Column<uint>(type: "int unsigned", nullable: false),
                    capacity = table.Column<uint>(type: "int unsigned", nullable: false),
                    backout_hours = table.Column<TimeOnly>(type: "time", nullable: false),
                    building_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.classroom_id);
                    table.ForeignKey(
                        name: "Classroom_FK",
                        column: x => x.building_name,
                        principalTable: "Building",
                        principalColumn: "building_name");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    department_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    building_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    budget = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.department_name);
                    table.ForeignKey(
                        name: "Department_FK",
                        column: x => x.building_name,
                        principalTable: "Building",
                        principalColumn: "building_name",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    course_id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    credits = table.Column<uint>(type: "int unsigned", nullable: false),
                    department_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.course_id);
                    table.ForeignKey(
                        name: "Course_FK",
                        column: x => x.department_name,
                        principalTable: "Department",
                        principalColumn: "department_name");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    request_id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descritption = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    classroom_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    department_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.request_id);
                    table.ForeignKey(
                        name: "Requests_FK",
                        column: x => x.classroom_id,
                        principalTable: "Classroom",
                        principalColumn: "classroom_id");
                    table.ForeignKey(
                        name: "Requests_FK_1",
                        column: x => x.department_name,
                        principalTable: "Department",
                        principalColumn: "department_name");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    equipment_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    equipment_type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    classroom_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    course_id = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.equipment_id);
                    table.ForeignKey(
                        name: "Equipment_FK",
                        column: x => x.classroom_id,
                        principalTable: "Classroom",
                        principalColumn: "classroom_id");
                    table.ForeignKey(
                        name: "Equipment_FK_1",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    section_id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    semester = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    year = table.Column<uint>(type: "int unsigned", nullable: false),
                    course_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    classroom_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    time_slot_id = table.Column<uint>(type: "int unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.section_id, x.course_id, x.semester, x.year })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });
                    table.ForeignKey(
                        name: "Section_FK",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "Section_FK_1",
                        column: x => x.classroom_id,
                        principalTable: "Classroom",
                        principalColumn: "classroom_id");
                    table.ForeignKey(
                        name: "Section_FK_2",
                        column: x => x.time_slot_id,
                        principalTable: "Time_Slot",
                        principalColumn: "time_slot_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "Classroom_FK",
                table: "Classroom",
                column: "building_name");

            migrationBuilder.CreateIndex(
                name: "Course_FK",
                table: "Course",
                column: "department_name");

            migrationBuilder.CreateIndex(
                name: "Department_FK",
                table: "Department",
                column: "building_name");

            migrationBuilder.CreateIndex(
                name: "Equipment_FK",
                table: "Equipment",
                column: "classroom_id");

            migrationBuilder.CreateIndex(
                name: "Equipment_FK_1",
                table: "Equipment",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "Requests_FK",
                table: "Requests",
                column: "classroom_id");

            migrationBuilder.CreateIndex(
                name: "Requests_FK_1",
                table: "Requests",
                column: "department_name");

            migrationBuilder.CreateIndex(
                name: "Section_FK",
                table: "Section",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "Section_FK_1",
                table: "Section",
                column: "classroom_id");

            migrationBuilder.CreateIndex(
                name: "Section_FK_2",
                table: "Section",
                column: "time_slot_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Time_Slot");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
