using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CourseManager.Infrastructure;

namespace CourseManager.Infrastructure.Migrations
{
    [DbContext(typeof(DbManager))]
    [Migration("20170118220245_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseManager.Core.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 512);

                    b.Property<Guid?>("OwnerId");

                    b.Property<int>("Semester");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseManager.Core.Models.CourseEmployee", b =>
                {
                    b.Property<Guid>("CourseId");

                    b.Property<Guid>("EmployeeId");

                    b.HasKey("CourseId", "EmployeeId");

                    b.HasIndex("CourseId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("CourseEmployees");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BaseId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CourseManager.Core.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("FilePath")
                        .IsRequired();

                    b.Property<int>("FileSize");

                    b.Property<Guid?>("OwnerId");

                    b.Property<DateTime>("UploadDateTime");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CourseId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("StudentId");

                    b.Property<Guid?>("TeacherId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<float>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<Guid?>("CourseId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("OwnerId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Seminar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<Guid?>("CourseId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 512);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Seminaries");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BaseId");

                    b.Property<int>("CurrentYear");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Group")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CourseManager.Core.Models.StudentCourse", b =>
                {
                    b.Property<Guid>("StudentId");

                    b.Property<Guid>("CourseId");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Course", b =>
                {
                    b.HasOne("CourseManager.Core.Models.Employee", "Owner")
                        .WithMany("Courses")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("CourseManager.Core.Models.CourseEmployee", b =>
                {
                    b.HasOne("CourseManager.Core.Models.Course", "Course")
                        .WithMany("CourseEmployees")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseManager.Core.Models.Employee", "Employee")
                        .WithMany("CourseEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseManager.Core.Models.File", b =>
                {
                    b.HasOne("CourseManager.Core.Models.Employee", "Owner")
                        .WithMany("Files")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Grade", b =>
                {
                    b.HasOne("CourseManager.Core.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("CourseManager.Core.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId");

                    b.HasOne("CourseManager.Core.Models.Employee", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Post", b =>
                {
                    b.HasOne("CourseManager.Core.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("CourseManager.Core.Models.Employee", "Owner")
                        .WithMany("Posts")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Seminar", b =>
                {
                    b.HasOne("CourseManager.Core.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("CourseManager.Core.Models.StudentCourse", b =>
                {
                    b.HasOne("CourseManager.Core.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseManager.Core.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
