using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconLMS.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2020, 6, 11, 19, 59, 1, 111, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2020, 6, 11, 19, 59, 1, 114, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2020, 6, 11, 19, 59, 1, 114, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 19, 59, 1, 115, DateTimeKind.Local).AddTicks(4019), new DateTime(2020, 6, 11, 19, 59, 1, 115, DateTimeKind.Local).AddTicks(2913) });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 19, 59, 1, 115, DateTimeKind.Local).AddTicks(4972), new DateTime(2020, 6, 11, 19, 59, 1, 115, DateTimeKind.Local).AddTicks(4951) });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 19, 59, 1, 115, DateTimeKind.Local).AddTicks(5133), new DateTime(2020, 6, 11, 19, 59, 1, 115, DateTimeKind.Local).AddTicks(5130) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 19, 59, 1, 116, DateTimeKind.Local).AddTicks(857), new DateTime(2020, 6, 11, 19, 59, 1, 115, DateTimeKind.Local).AddTicks(9946) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 19, 59, 1, 116, DateTimeKind.Local).AddTicks(1874), new DateTime(2020, 6, 11, 19, 59, 1, 116, DateTimeKind.Local).AddTicks(1836) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 19, 59, 1, 116, DateTimeKind.Local).AddTicks(1896), new DateTime(2020, 6, 11, 19, 59, 1, 116, DateTimeKind.Local).AddTicks(1892) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2020, 6, 11, 17, 51, 23, 520, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2020, 6, 11, 17, 51, 23, 524, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2020, 6, 11, 17, 51, 23, 524, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(987), new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(488) });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(1537), new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(1519) });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(1550), new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(1547) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(4169), new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(3693) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(4704), new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(4686) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(4717), new DateTime(2020, 6, 11, 17, 51, 23, 525, DateTimeKind.Local).AddTicks(4714) });
        }
    }
}
