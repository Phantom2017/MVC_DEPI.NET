﻿// <auto-generated />
using MVC_Day1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_Day1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240926162926_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_Day1.Models.Department", b =>
                {
                    b.Property<int>("DeptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptID"));

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DeptID = 1,
                            ManagerName = "Ahmed Salah",
                            Name = "SD"
                        },
                        new
                        {
                            DeptID = 2,
                            ManagerName = "Asmaa Mohamed",
                            Name = "Hr"
                        },
                        new
                        {
                            DeptID = 3,
                            ManagerName = "Ali Essam",
                            Name = "Finance"
                        });
                });

            modelBuilder.Entity("MVC_Day1.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<int>("deptId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("deptId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Assiut",
                            Img = "f.jpg",
                            Name = "Amany Farouk",
                            Salary = 3500,
                            deptId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Assiut",
                            Img = "f.jpg",
                            Name = "Amira Ahmed",
                            Salary = 4000,
                            deptId = 2
                        },
                        new
                        {
                            Id = 3,
                            Address = "Assiut",
                            Img = "m.jpg",
                            Name = "Abanoub Gaber",
                            Salary = 5000,
                            deptId = 3
                        },
                        new
                        {
                            Id = 4,
                            Address = "Assiut",
                            Img = "m.jpg",
                            Name = "Amir Mostafa",
                            Salary = 4000,
                            deptId = 2
                        });
                });

            modelBuilder.Entity("MVC_Day1.Models.Employee", b =>
                {
                    b.HasOne("MVC_Day1.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("deptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC_Day1.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
