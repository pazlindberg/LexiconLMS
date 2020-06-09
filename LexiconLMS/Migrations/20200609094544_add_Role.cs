using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconLMS.Migrations
{
    public partial class add_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2020, 6, 9, 11, 45, 44, 22, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 9, 11, 45, 44, 29, DateTimeKind.Local).AddTicks(1361), new DateTime(2020, 6, 9, 11, 45, 44, 29, DateTimeKind.Local).AddTicks(533) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 9, 11, 45, 44, 29, DateTimeKind.Local).AddTicks(6084), new DateTime(2020, 6, 9, 11, 45, 44, 29, DateTimeKind.Local).AddTicks(5239) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2020, 6, 8, 14, 41, 4, 28, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 8, 14, 41, 4, 32, DateTimeKind.Local).AddTicks(6844), new DateTime(2020, 6, 8, 14, 41, 4, 32, DateTimeKind.Local).AddTicks(5934) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 8, 14, 41, 4, 33, DateTimeKind.Local).AddTicks(2341), new DateTime(2020, 6, 8, 14, 41, 4, 33, DateTimeKind.Local).AddTicks(1495) });
        }
    }
}
