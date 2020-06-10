using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconLMS.Migrations
{
    public partial class brainlost2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2020, 6, 10, 13, 33, 57, 652, DateTimeKind.Local).AddTicks(8204));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 10, 13, 33, 57, 656, DateTimeKind.Local).AddTicks(9522), new DateTime(2020, 6, 10, 13, 33, 57, 656, DateTimeKind.Local).AddTicks(8652) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 10, 13, 33, 57, 657, DateTimeKind.Local).AddTicks(4726), new DateTime(2020, 6, 10, 13, 33, 57, 657, DateTimeKind.Local).AddTicks(3934) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2020, 6, 10, 10, 28, 46, 403, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 10, 10, 28, 46, 412, DateTimeKind.Local).AddTicks(9304), new DateTime(2020, 6, 10, 10, 28, 46, 412, DateTimeKind.Local).AddTicks(8142) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 10, 10, 28, 46, 413, DateTimeKind.Local).AddTicks(6190), new DateTime(2020, 6, 10, 10, 28, 46, 413, DateTimeKind.Local).AddTicks(5125) });
        }
    }
}
