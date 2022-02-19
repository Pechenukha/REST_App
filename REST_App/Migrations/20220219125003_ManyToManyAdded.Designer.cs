﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using REST_App.Models;

namespace REST_App.Migrations
{
    [DbContext(typeof(CollegeContext))]
    [Migration("20220219125003_ManyToManyAdded")]
    partial class ManyToManyAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("REST_App.Models.Faculty", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("head_of_faculty")
                        .HasColumnType("text");

                    b.Property<string>("name_of_faculty")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("faculty");
                });

            modelBuilder.Entity("REST_App.Models.Group", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("curator")
                        .HasColumnType("text");

                    b.Property<string>("number_of_group")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("REST_App.Models.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("course")
                        .HasColumnType("integer");

                    b.Property<int?>("facultyid")
                        .HasColumnType("integer");

                    b.Property<int>("id_faculty")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("speciality")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("facultyid");

                    b.ToTable("student");
                });

            modelBuilder.Entity("REST_App.Models.StudentInGroup", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("id_group")
                        .HasColumnType("integer");

                    b.Property<int>("id_student")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("id_group");

                    b.HasIndex("id_student");

                    b.ToTable("student_in_group");
                });

            modelBuilder.Entity("REST_App.Models.Student", b =>
                {
                    b.HasOne("REST_App.Models.Faculty", "faculty")
                        .WithMany("student")
                        .HasForeignKey("facultyid");

                    b.Navigation("faculty");
                });

            modelBuilder.Entity("REST_App.Models.StudentInGroup", b =>
                {
                    b.HasOne("REST_App.Models.Group", "groups")
                        .WithMany("student_in_group")
                        .HasForeignKey("id_group")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("REST_App.Models.Student", "student")
                        .WithMany("student_in_group")
                        .HasForeignKey("id_student")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("groups");

                    b.Navigation("student");
                });

            modelBuilder.Entity("REST_App.Models.Faculty", b =>
                {
                    b.Navigation("student");
                });

            modelBuilder.Entity("REST_App.Models.Group", b =>
                {
                    b.Navigation("student_in_group");
                });

            modelBuilder.Entity("REST_App.Models.Student", b =>
                {
                    b.Navigation("student_in_group");
                });
#pragma warning restore 612, 618
        }
    }
}
