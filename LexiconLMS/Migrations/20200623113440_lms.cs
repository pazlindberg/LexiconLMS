using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconLMS.Migrations
{
    public partial class lms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 31, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    TaskTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, "Grundkurs i Office 365", "Office 365", new DateTime(2020, 6, 23, 13, 34, 39, 718, DateTimeKind.Local).AddTicks(6781) },
                    { 2, "Påbyggnadskurs i SQL", "Databaser 2", new DateTime(2020, 6, 23, 13, 34, 39, 721, DateTimeKind.Local).AddTicks(3772) },
                    { 3, "Hur man skriver tester", "Test", new DateTime(2020, 6, 23, 13, 34, 39, 721, DateTimeKind.Local).AddTicks(3817) },
                    { 4, "C#", "Programmering", new DateTime(2020, 6, 23, 13, 34, 39, 721, DateTimeKind.Local).AddTicks(3823) }
                });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Föreläsning" },
                    { 2, "E-Learniog" },
                    { 3, "Inlämningsuppgift" },
                    { 4, "Prov" },
                    { 5, "Certifiering" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Description", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, "Skriva formler i Excel", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(513), "Excel", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(9) },
                    { 2, 1, "Skriva dokument", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(988), "Word", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(973) },
                    { 3, 2, "Skapa en enkel databas", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(1000), "Skapa databaser", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(997) },
                    { 4, 2, "Hur söker man i en databas?", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(1006), "Söka i databaser", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(1003) },
                    { 5, 2, "Hur man ska arbeta med mer än en databas", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(1011), "Arbeta med flera databaser", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(1008) },
                    { 6, 3, "Automatisering av tester", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(1016), "Automatisering", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(1014) },
                    { 7, 4, "Vad är objekt?", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(1022), "Objekt", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(1019) }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "EndDate", "ModuleId", "Name", "StartDate", "TaskTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(4883), 1, "Enkla formler(addition, subtraktion...)", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(4468), 1 },
                    { 2, new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5408), 2, "Hur man använder ett tangentbord för att få tecken på skärmen", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5391), 2 },
                    { 3, new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5428), 3, "Skapa en databas för telefonnummer", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5426), 3 },
                    { 4, new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5434), 4, "Basic queries", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5431), 2 },
                    { 5, new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5439), 5, "Telefonnummer som är kopplade till en användare", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5437), 4 },
                    { 6, new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5444), 6, "Skriva ett test", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5442), 1 },
                    { 7, new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5449), 7, "Objektorienterad programmering", new DateTime(2020, 6, 23, 13, 34, 39, 723, DateTimeKind.Local).AddTicks(5447), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CourseId",
                table: "AspNetUsers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseId",
                table: "Modules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ModuleId",
                table: "Tasks",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
