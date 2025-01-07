﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20250107084814_Initails")]
    partial class Initails
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("DesignationId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 101,
                            DesignationId = 201,
                            Email = "john.doe@example.com",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 102,
                            DesignationId = 202,
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 103,
                            DesignationId = 203,
                            Email = "emily.johnson@example.com",
                            Name = "Emily Johnson"
                        },
                        new
                        {
                            Id = 4,
                            DepartmentId = 104,
                            DesignationId = 204,
                            Email = "michael.brown@example.com",
                            Name = "Michael Brown"
                        },
                        new
                        {
                            Id = 5,
                            DepartmentId = 105,
                            DesignationId = 205,
                            Email = "sarah.davis@example.com",
                            Name = "Sarah Davis"
                        },
                        new
                        {
                            Id = 6,
                            DepartmentId = 106,
                            DesignationId = 206,
                            Email = "david.wilson@example.com",
                            Name = "David Wilson"
                        },
                        new
                        {
                            Id = 7,
                            DepartmentId = 107,
                            DesignationId = 207,
                            Email = "laura.martinez@example.com",
                            Name = "Laura Martinez"
                        },
                        new
                        {
                            Id = 8,
                            DepartmentId = 108,
                            DesignationId = 208,
                            Email = "james.anderson@example.com",
                            Name = "James Anderson"
                        },
                        new
                        {
                            Id = 9,
                            DepartmentId = 109,
                            DesignationId = 209,
                            Email = "linda.thomas@example.com",
                            Name = "Linda Thomas"
                        },
                        new
                        {
                            Id = 10,
                            DepartmentId = 110,
                            DesignationId = 210,
                            Email = "robert.moore@example.com",
                            Name = "Robert Moore"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}