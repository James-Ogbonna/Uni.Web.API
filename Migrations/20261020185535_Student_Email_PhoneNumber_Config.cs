using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class Student_Email_PhoneNumber_Config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                schema: "public",
                table: "students",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "public",
                table: "students",
                type: "character varying(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                schema: "public",
                table: "students",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "public",
                table: "students",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(70)",
                oldMaxLength: 70);
        }
    }
}
