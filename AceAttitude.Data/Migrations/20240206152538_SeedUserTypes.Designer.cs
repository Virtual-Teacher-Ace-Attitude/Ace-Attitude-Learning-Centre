﻿// <auto-generated />
using System;
using AceAttitude.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AceAttitude.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240206152538_SeedUserTypes")]
    partial class SeedUserTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AceAttitude.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoteFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.HasIndex("TeacherId")
                        .IsUnique()
                        .HasFilter("[TeacherId] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "64dfe826-08e8-4dcf-888b-c441fead8803",
                            CreatedOn = new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Email = "student1@abv.bg",
                            FirstName = "Student",
                            LastName = "One",
                            PasswordHash = "$2a$11$p4falukZH9ovaApIH6O1T.TbAbwVphyDAVkg2YaFYF7LE6/f79a.6",
                            StudentId = "64dfe826-08e8-4dcf-888b-c441fead8803",
                            UserType = 0
                        },
                        new
                        {
                            Id = "11d15832-b94e-4be4-a892-14a07641adc3",
                            CreatedOn = new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Email = "student2@abv.bg",
                            FirstName = "Student",
                            LastName = "Two",
                            PasswordHash = "$2a$11$p4falukZH9ovaApIH6O1T.TbAbwVphyDAVkg2YaFYF7LE6/f79a.6",
                            StudentId = "11d15832-b94e-4be4-a892-14a07641adc3",
                            UserType = 0
                        },
                        new
                        {
                            Id = "5422e8d8-d114-42b1-b878-f410f14e0be7",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Email = "student3@abv.bg",
                            FirstName = "Student",
                            LastName = "Three",
                            PasswordHash = "$2a$11$p4falukZH9ovaApIH6O1T.TbAbwVphyDAVkg2YaFYF7LE6/f79a.6",
                            StudentId = "5422e8d8-d114-42b1-b878-f410f14e0be7",
                            UserType = 0
                        },
                        new
                        {
                            Id = "22cbe4de-2827-4458-b55f-779a19400ab5",
                            CreatedOn = new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Email = "teacher1@abv.bg",
                            FirstName = "Alexei",
                            LastName = "Kalionski",
                            PasswordHash = "$2a$11$p4falukZH9ovaApIH6O1T.TbAbwVphyDAVkg2YaFYF7LE6/f79a.6",
                            TeacherId = "22cbe4de-2827-4458-b55f-779a19400ab5",
                            UserType = 2
                        },
                        new
                        {
                            Id = "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                            CreatedOn = new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Email = "teacher2@abv.bg",
                            FirstName = "Alexander",
                            LastName = "Arabadzhiev",
                            PasswordHash = "$2a$11$p4falukZH9ovaApIH6O1T.TbAbwVphyDAVkg2YaFYF7LE6/f79a.6",
                            TeacherId = "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                            UserType = 2
                        },
                        new
                        {
                            Id = "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Email = "teacher3@abv.bg",
                            FirstName = "Georgi",
                            LastName = "Aleksandrov",
                            PasswordHash = "$2a$11$p4falukZH9ovaApIH6O1T.TbAbwVphyDAVkg2YaFYF7LE6/f79a.6",
                            TeacherId = "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                            UserType = 1
                        });
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CourseId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "64dfe826-08e8-4dcf-888b-c441fead8803",
                            Content = "Content of comment 1.",
                            CourseId = 1,
                            CreatedOn = new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Likes = 1
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "11d15832-b94e-4be4-a892-14a07641adc3",
                            Content = "Content of comment 2.",
                            CourseId = 2,
                            CreatedOn = new DateTime(2024, 2, 20, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Likes = 2
                        },
                        new
                        {
                            Id = 3,
                            ApplicationUserId = "5422e8d8-d114-42b1-b878-f410f14e0be7",
                            Content = "Content of comment 3.",
                            CourseId = 3,
                            CreatedOn = new DateTime(2024, 3, 9, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Likes = 3
                        });
                });

            modelBuilder.Entity("AceAttitude.Data.Models.CommentLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsLiked")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentLikes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "64dfe826-08e8-4dcf-888b-c441fead8803",
                            CommentId = 1,
                            CreatedOn = new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsLiked = true
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "11d15832-b94e-4be4-a892-14a07641adc3",
                            CommentId = 2,
                            CreatedOn = new DateTime(2024, 2, 21, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsLiked = true
                        },
                        new
                        {
                            Id = 3,
                            ApplicationUserId = "5422e8d8-d114-42b1-b878-f410f14e0be7",
                            CommentId = 3,
                            CreatedOn = new DateTime(2024, 3, 11, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsLiked = true
                        },
                        new
                        {
                            Id = 4,
                            ApplicationUserId = "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                            CommentId = 3,
                            CreatedOn = new DateTime(2024, 3, 12, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsLiked = false
                        });
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgeGroup")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDraft")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgeGroup = 0,
                            CreatedOn = new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Description = "Description of course 1.",
                            IsCompleted = true,
                            IsDraft = false,
                            Level = 1,
                            StartingDate = new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            TeacherId = "22cbe4de-2827-4458-b55f-779a19400ab5",
                            Title = "Course 1"
                        },
                        new
                        {
                            Id = 2,
                            AgeGroup = 1,
                            CreatedOn = new DateTime(2024, 2, 13, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Description = "Description of course 2.",
                            IsCompleted = false,
                            IsDraft = false,
                            Level = 3,
                            StartingDate = new DateTime(2024, 3, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            TeacherId = "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                            Title = "Course 2"
                        },
                        new
                        {
                            Id = 3,
                            AgeGroup = 2,
                            CreatedOn = new DateTime(2024, 3, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Description = "Description of course 3.",
                            IsCompleted = false,
                            IsDraft = true,
                            Level = 5,
                            StartingDate = new DateTime(2024, 4, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            TeacherId = "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                            Title = "Course 3"
                        });
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("TextFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VideoFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lectures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            CreatedOn = new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Description = "Description of lecture 1.",
                            Title = "Lecture 1"
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 2,
                            CreatedOn = new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Description = "Description of lecture 2.",
                            Title = "Lecture 2"
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 3,
                            CreatedOn = new DateTime(2024, 2, 8, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            Description = "Description of lecture 3.",
                            Title = "Lecture 3"
                        });
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRated")
                        .HasColumnType("bit");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            CreatedOn = new DateTime(2024, 2, 9, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsRated = true,
                            StudentId = "64dfe826-08e8-4dcf-888b-c441fead8803",
                            Value = 5.0m
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            CreatedOn = new DateTime(2024, 2, 10, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsRated = true,
                            StudentId = "11d15832-b94e-4be4-a892-14a07641adc3",
                            Value = 4.5m
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 1,
                            CreatedOn = new DateTime(2024, 2, 11, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsRated = false,
                            StudentId = "5422e8d8-d114-42b1-b878-f410f14e0be7",
                            Value = 4.5m
                        });
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Student", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = "64dfe826-08e8-4dcf-888b-c441fead8803",
                            ApplicationUserId = "64dfe826-08e8-4dcf-888b-c441fead8803",
                            CreatedOn = new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133)
                        },
                        new
                        {
                            Id = "11d15832-b94e-4be4-a892-14a07641adc3",
                            ApplicationUserId = "11d15832-b94e-4be4-a892-14a07641adc3",
                            CreatedOn = new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133)
                        },
                        new
                        {
                            Id = "5422e8d8-d114-42b1-b878-f410f14e0be7",
                            ApplicationUserId = "5422e8d8-d114-42b1-b878-f410f14e0be7",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133)
                        });
                });

            modelBuilder.Entity("AceAttitude.Data.Models.StudentCourses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            CreatedOn = new DateTime(2024, 2, 3, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsCompleted = true,
                            StudentId = "64dfe826-08e8-4dcf-888b-c441fead8803"
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            CreatedOn = new DateTime(2024, 2, 2, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsCompleted = true,
                            StudentId = "11d15832-b94e-4be4-a892-14a07641adc3"
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 1,
                            CreatedOn = new DateTime(2024, 2, 1, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsCompleted = true,
                            StudentId = "5422e8d8-d114-42b1-b878-f410f14e0be7"
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            CreatedOn = new DateTime(2024, 2, 14, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsCompleted = false,
                            StudentId = "64dfe826-08e8-4dcf-888b-c441fead8803"
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 2,
                            CreatedOn = new DateTime(2024, 2, 15, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsCompleted = false,
                            StudentId = "11d15832-b94e-4be4-a892-14a07641adc3"
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 2,
                            CreatedOn = new DateTime(2024, 2, 16, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsCompleted = false,
                            StudentId = "5422e8d8-d114-42b1-b878-f410f14e0be7"
                        });
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Teacher", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = "22cbe4de-2827-4458-b55f-779a19400ab5",
                            ApplicationUserId = "22cbe4de-2827-4458-b55f-779a19400ab5",
                            CreatedOn = new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsAdmin = true,
                            IsApproved = true
                        },
                        new
                        {
                            Id = "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                            ApplicationUserId = "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                            CreatedOn = new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsAdmin = true,
                            IsApproved = true
                        },
                        new
                        {
                            Id = "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                            ApplicationUserId = "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                            CreatedOn = new DateTime(2024, 2, 8, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133),
                            IsAdmin = false,
                            IsApproved = true
                        });
                });

            modelBuilder.Entity("AceAttitude.Data.Models.ApplicationUser", b =>
                {
                    b.HasOne("AceAttitude.Data.Models.Student", "Student")
                        .WithOne("User")
                        .HasForeignKey("AceAttitude.Data.Models.ApplicationUser", "StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AceAttitude.Data.Models.Teacher", "Teacher")
                        .WithOne("User")
                        .HasForeignKey("AceAttitude.Data.Models.ApplicationUser", "TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Comment", b =>
                {
                    b.HasOne("AceAttitude.Data.Models.ApplicationUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AceAttitude.Data.Models.Course", "Course")
                        .WithMany("Comments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AceAttitude.Data.Models.CommentLike", b =>
                {
                    b.HasOne("AceAttitude.Data.Models.ApplicationUser", "User")
                        .WithMany("CommentLikes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AceAttitude.Data.Models.Comment", "Comment")
                        .WithMany("CommentLikes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Course", b =>
                {
                    b.HasOne("AceAttitude.Data.Models.Teacher", "Teacher")
                        .WithMany("CreatedCourses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Lecture", b =>
                {
                    b.HasOne("AceAttitude.Data.Models.Course", "Course")
                        .WithMany("Lectures")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Rating", b =>
                {
                    b.HasOne("AceAttitude.Data.Models.Course", "Course")
                        .WithMany("Ratings")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AceAttitude.Data.Models.Student", "Student")
                        .WithMany("Ratings")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AceAttitude.Data.Models.StudentCourses", b =>
                {
                    b.HasOne("AceAttitude.Data.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AceAttitude.Data.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AceAttitude.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("CommentLikes");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Comment", b =>
                {
                    b.Navigation("CommentLikes");
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Course", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Lectures");

                    b.Navigation("Ratings");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Student", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("StudentCourses");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("AceAttitude.Data.Models.Teacher", b =>
                {
                    b.Navigation("CreatedCourses");

                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
