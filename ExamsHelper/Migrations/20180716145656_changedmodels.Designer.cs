﻿// <auto-generated />
using ExamsHelper.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ExamsHelper.Migrations
{
    [DbContext(typeof(dbcontext))]
    [Migration("20180716145656_changedmodels")]
    partial class changedmodels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExamsHelper.Models.Faculties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameOfFaculties");

                    b.Property<int>("UniverId");

                    b.Property<int?>("UniversId");

                    b.HasKey("Id");

                    b.HasIndex("UniversId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("ExamsHelper.Models.Lections", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<int>("SubjectsId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectsId");

                    b.HasIndex("UserId");

                    b.ToTable("Lections");
                });

            modelBuilder.Entity("ExamsHelper.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<int>("NumberOfQuestion");

                    b.Property<string>("Question");

                    b.Property<int>("SubjectsId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectsId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ExamsHelper.Models.Subjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FacultiesId");

                    b.Property<string>("NameOfSubject");

                    b.Property<string>("Speciality");

                    b.Property<string>("Teacher");

                    b.HasKey("Id");

                    b.HasIndex("FacultiesId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ExamsHelper.Models.Univers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameOfUniver");

                    b.Property<string>("Town");

                    b.HasKey("Id");

                    b.ToTable("Univers");
                });

            modelBuilder.Entity("ExamsHelper.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int>("FacultiesId");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<int>("UniversId");

                    b.HasKey("Id");

                    b.HasIndex("FacultiesId");

                    b.HasIndex("UniversId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExamsHelper.Models.Faculties", b =>
                {
                    b.HasOne("ExamsHelper.Models.Univers", "Univers")
                        .WithMany("Faculties")
                        .HasForeignKey("UniversId");
                });

            modelBuilder.Entity("ExamsHelper.Models.Lections", b =>
                {
                    b.HasOne("ExamsHelper.Models.Subjects", "Subjects")
                        .WithMany("Lections")
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExamsHelper.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ExamsHelper.Models.Questions", b =>
                {
                    b.HasOne("ExamsHelper.Models.Subjects", "Subjects")
                        .WithMany("Questions")
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamsHelper.Models.Subjects", b =>
                {
                    b.HasOne("ExamsHelper.Models.Faculties", "Faculties")
                        .WithMany("Subjects")
                        .HasForeignKey("FacultiesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamsHelper.Models.User", b =>
                {
                    b.HasOne("ExamsHelper.Models.Faculties", "Faculties")
                        .WithMany("Users")
                        .HasForeignKey("FacultiesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExamsHelper.Models.Univers", "Univers")
                        .WithMany("Users")
                        .HasForeignKey("UniversId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
