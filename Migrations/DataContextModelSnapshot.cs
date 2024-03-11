﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Unicon.Data;

#nullable disable

namespace Unicon.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Unicon.Data.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentId"));

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EntityId")
                        .HasColumnType("integer");

                    b.Property<int>("Point")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("CommentId");

                    b.HasIndex("EntityId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Unicon.Data.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CoursePoint")
                        .HasColumnType("integer");

                    b.Property<int>("InstructorId")
                        .HasColumnType("integer");

                    b.HasKey("CourseId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Unicon.Data.Entity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EntityId"));

                    b.Property<string>("EntityName")
                        .HasColumnType("text");

                    b.HasKey("EntityId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("Unicon.Data.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InstructorId"));

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("InstructorPoint")
                        .HasColumnType("integer");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Unicon.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("RealName")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Unicon.Data.Comment", b =>
                {
                    b.HasOne("Unicon.Data.Entity", "EntityType")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unicon.Data.User", "CommentedBy")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommentedBy");

                    b.Navigation("EntityType");
                });

            modelBuilder.Entity("Unicon.Data.Course", b =>
                {
                    b.HasOne("Unicon.Data.Instructor", "Instructor")
                        .WithMany("CoursesGiven")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Unicon.Data.Instructor", b =>
                {
                    b.Navigation("CoursesGiven");
                });
#pragma warning restore 612, 618
        }
    }
}
