﻿// <auto-generated />
using CoreMvcCrudProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreMvcCrudProject.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreMvcCrudProject.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CoreMvcCrudProject.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentID");

                    b.Property<string>("StudentContact")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("StudentRoll")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("StudentId");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CoreMvcCrudProject.Models.Student", b =>
                {
                    b.HasOne("CoreMvcCrudProject.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
