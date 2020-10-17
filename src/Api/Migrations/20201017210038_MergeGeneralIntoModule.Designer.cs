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
    [Migration("20201017210038_MergeGeneralIntoModule")]
    partial class MergeGeneralIntoModule
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

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

                    b.Property<string>("Course")
                        .HasColumnType("text");

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
