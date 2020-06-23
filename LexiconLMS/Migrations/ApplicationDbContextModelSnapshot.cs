﻿// <auto-generated />
using System;
using LexiconLMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LexiconLMS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LexiconLMS.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(31)")
                        .HasMaxLength(31);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Grundkurs i Office 365",
                            Name = "Office 365",
                            StartDate = new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Påbyggnadskurs i SQL",
                            Name = "Databaser 2",
                            StartDate = new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Description = "Hur man skriver tester",
                            Name = "Test",
                            StartDate = new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Description = "C#",
                            Name = "Programmering",
                            StartDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LexiconLMS.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Modules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Description = "Skriva formler i Excel",
                            EndDate = new DateTime(2020, 6, 20, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Excel",
                            StartDate = new DateTime(2020, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Description = "Skriva dokument",
                            EndDate = new DateTime(2020, 6, 30, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Word",
                            StartDate = new DateTime(2020, 6, 21, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 2,
                            Description = "Skapa en enkel databas",
                            EndDate = new DateTime(2020, 4, 10, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Skapa databaser",
                            StartDate = new DateTime(2020, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            Description = "Hur söker man i en databas?",
                            EndDate = new DateTime(2020, 4, 12, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Söka i databaser",
                            StartDate = new DateTime(2020, 4, 11, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 2,
                            Description = "Hur man ska arbeta med mer än en databas",
                            EndDate = new DateTime(2020, 4, 20, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Arbeta med flera databaser",
                            StartDate = new DateTime(2020, 4, 13, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 3,
                            Description = "Automatisering av tester",
                            EndDate = new DateTime(2020, 10, 20, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Automatisering",
                            StartDate = new DateTime(2020, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            CourseId = 4,
                            Description = "Vad är objekt?",
                            EndDate = new DateTime(2020, 12, 24, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Objekt",
                            StartDate = new DateTime(2020, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LexiconLMS.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2020, 6, 15, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            ModuleId = 1,
                            Name = "Enkla formler(addition, subtraktion...)",
                            StartDate = new DateTime(2020, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateTime(2020, 6, 22, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            ModuleId = 2,
                            Name = "Hur man använder ett tangentbord för att få tecken på skärmen",
                            StartDate = new DateTime(2020, 6, 21, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskTypeId = 2
                        },
                        new
                        {
                            Id = 3,
                            EndDate = new DateTime(2020, 4, 10, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            ModuleId = 3,
                            Name = "Skapa en databas för telefonnummer",
                            StartDate = new DateTime(2020, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskTypeId = 3
                        },
                        new
                        {
                            Id = 4,
                            EndDate = new DateTime(2020, 4, 11, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            ModuleId = 4,
                            Name = "Basic queries",
                            StartDate = new DateTime(2020, 4, 11, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskTypeId = 2
                        },
                        new
                        {
                            Id = 5,
                            EndDate = new DateTime(2020, 4, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            ModuleId = 5,
                            Name = "Telefonnummer som är kopplade till en användare",
                            StartDate = new DateTime(2020, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskTypeId = 4
                        },
                        new
                        {
                            Id = 6,
                            EndDate = new DateTime(2020, 8, 1, 11, 30, 0, 0, DateTimeKind.Unspecified),
                            ModuleId = 6,
                            Name = "Skriva ett test",
                            StartDate = new DateTime(2020, 8, 1, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            TaskTypeId = 1
                        },
                        new
                        {
                            Id = 7,
                            EndDate = new DateTime(2020, 12, 23, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            ModuleId = 7,
                            Name = "Objektorienterad programmering",
                            StartDate = new DateTime(2020, 12, 23, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            TaskTypeId = 5
                        });
                });

            modelBuilder.Entity("LexiconLMS.Models.TaskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaskTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Föreläsning"
                        },
                        new
                        {
                            Id = 2,
                            Name = "E-Learning"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Inlämningsuppgift"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Prov"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Certifiering"
                        });
                });

            modelBuilder.Entity("LexiconLMS.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LexiconLMS.Models.Module", b =>
                {
                    b.HasOne("LexiconLMS.Models.Course", "Course")
                        .WithMany("Modules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LexiconLMS.Models.Task", b =>
                {
                    b.HasOne("LexiconLMS.Models.Module", "Module")
                        .WithMany("Tasks")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LexiconLMS.Models.TaskType", "TaskType")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LexiconLMS.Models.User", b =>
                {
                    b.HasOne("LexiconLMS.Models.Course", "Course")
                        .WithMany("Users")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LexiconLMS.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LexiconLMS.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LexiconLMS.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LexiconLMS.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
