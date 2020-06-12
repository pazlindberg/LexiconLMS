using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconLMS.Migrations
{
    public partial class TaskTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskType_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskType",
                table: "TaskType");

            migrationBuilder.RenameTable(
                name: "TaskType",
                newName: "TaskTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskTypes",
                table: "TaskTypes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2020, 6, 11, 12, 44, 27, 393, DateTimeKind.Local).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 12, 44, 27, 395, DateTimeKind.Local).AddTicks(6890), new DateTime(2020, 6, 11, 12, 44, 27, 395, DateTimeKind.Local).AddTicks(6368) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 6, 11, 12, 44, 27, 396, DateTimeKind.Local).AddTicks(117), new DateTime(2020, 6, 11, 12, 44, 27, 395, DateTimeKind.Local).AddTicks(9600) });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskTypes",
                table: "TaskTypes");

            migrationBuilder.RenameTable(
                name: "TaskTypes",
                newName: "TaskType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskType",
                table: "TaskType",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskType_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId",
                principalTable: "TaskType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
