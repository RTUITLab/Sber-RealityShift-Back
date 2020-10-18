﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Api.Migrations
{
    [DbContext(typeof(SberDbContext))]
    [Migration("20201018024802_CourseModel")]
    partial class CourseModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("text");

                    b.Property<string>("AnswerAuthor")
                        .HasColumnType("text");

                    b.Property<DateTime?>("AnsweredTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DoneTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<int>("ModuleId")
                        .HasColumnType("integer");

                    b.Property<int>("Part")
                        .HasColumnType("integer");

                    b.Property<string>("PathToField")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BasicIdea")
                        .HasColumnType("text");

                    b.Property<int>("ClassLevel")
                        .HasColumnType("integer");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<string>("Creator")
                        .HasColumnType("text");

                    b.Property<bool>("Done")
                        .HasColumnType("boolean");

                    b.Property<double>("LaborIntensity")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("LastEditTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProblemQuestion")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("Visibility")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Models.ModuleTeacherInstructions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Challenges")
                        .HasColumnType("text");

                    b.Property<string>("ExercisesByLessons")
                        .HasColumnType("text");

                    b.Property<string>("GeneralMeaning")
                        .HasColumnType("text");

                    b.Property<int>("ModuleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId")
                        .IsUnique();

                    b.ToTable("TeacherInstructions");
                });

            modelBuilder.Entity("Models.Tag", b =>
                {
                    b.Property<int>("ModuleId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("ModuleId", "Value");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.HasOne("Models.Module", "Module")
                        .WithMany("Comments")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Module", b =>
                {
                    b.HasOne("Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.ModuleTeacherInstructions", b =>
                {
                    b.HasOne("Models.Module", "Module")
                        .WithOne("TeacherInstructions")
                        .HasForeignKey("Models.ModuleTeacherInstructions", "ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Tag", b =>
                {
                    b.HasOne("Models.Module", "Module")
                        .WithMany("Tags")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
