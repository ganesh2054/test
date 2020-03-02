﻿// <auto-generated />
using System;
using CollegeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CollegeManagement.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20191108222344_studentmigration")]
    partial class studentmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CollegeManagement.Models.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Email");

                    b.Property<int>("Faculty");

                    b.Property<int?>("Gender");

                    b.Property<string>("Name");

                    b.Property<string>("Phon");

                    b.Property<string>("PhotoPath");

                    b.HasKey("id");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}