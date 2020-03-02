using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeManagement.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "id", "Address", "Birthday", "Email", "Faculty", "Gender", "Name", "Phon", "PhotoPath" },
                values: new object[] { 1, "kathmandu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lmeganesh@gmail.com", 0, null, "Mark", "34579375", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "id", "Address", "Birthday", "Email", "Faculty", "Gender", "Name", "Phon", "PhotoPath" },
                values: new object[] { 2, "ktm", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lmeUmeshsh@gmail.com", 0, null, "Mark", "34579375", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
