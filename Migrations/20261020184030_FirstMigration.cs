using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "courses",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    unit = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schools",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_schools", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    school_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departments", x => x.id);
                    table.ForeignKey(
                        name: "fk_departments_schools_school_id",
                        column: x => x.school_id,
                        principalSchema: "public",
                        principalTable: "schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departmental_courses",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    department_id = table.Column<Guid>(type: "uuid", nullable: false),
                    course_id = table.Column<Guid>(type: "uuid", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    semester = table.Column<int>(type: "integer", maxLength: 1, nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departmental_courses", x => x.id);
                    table.ForeignKey(
                        name: "fk_departmental_courses_courses_course_id",
                        column: x => x.course_id,
                        principalSchema: "public",
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_departmental_courses_departments_department_id",
                        column: x => x.department_id,
                        principalSchema: "public",
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    reg_number = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    first_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    last_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    department_id = table.Column<Guid>(type: "uuid", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.id);
                    table.ForeignKey(
                        name: "fk_students_departments_department_id",
                        column: x => x.department_id,
                        principalSchema: "public",
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_registrations",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    course_id = table.Column<Guid>(type: "uuid", nullable: false),
                    session = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    semester = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_registrations", x => x.id);
                    table.ForeignKey(
                        name: "fk_course_registrations_courses_course_id",
                        column: x => x.course_id,
                        principalSchema: "public",
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_course_registrations_students_student_id",
                        column: x => x.student_id,
                        principalSchema: "public",
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_course_registrations_course_id",
                schema: "public",
                table: "course_registrations",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_course_registrations_student_id",
                schema: "public",
                table: "course_registrations",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_departmental_courses_course_id",
                schema: "public",
                table: "departmental_courses",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "ix_departmental_courses_department_id_course_id",
                schema: "public",
                table: "departmental_courses",
                columns: new[] { "department_id", "course_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_departments_school_id",
                schema: "public",
                table: "departments",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "ix_students_department_id",
                schema: "public",
                table: "students",
                column: "department_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course_registrations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "departmental_courses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "students",
                schema: "public");

            migrationBuilder.DropTable(
                name: "courses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "departments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "schools",
                schema: "public");
        }
    }
}
