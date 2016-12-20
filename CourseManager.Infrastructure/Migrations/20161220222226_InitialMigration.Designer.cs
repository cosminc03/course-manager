using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CourseManager.Infrastructure;

namespace CourseManager.Infrastructure.Migrations
{
    [DbContext(typeof(DbManager))]
    [Migration("20161220222226_InitialMigration")]
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

                    b.Property<string>("Description");

                    b.Property<Guid?>("OwnerId");

                    b.Property<int>("Semester");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseManager.Core.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileExtension");

                    b.Property<string>("FileName");

                    b.Property<string>("FilePath");

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

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("StudentId");

                    b.Property<Guid>("TeacherId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<float>("Value");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CourseManager.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BaseId");

                    b.Property<Guid?>("CourseId");

                    b.Property<int>("CurrentYear");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("Group");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Course", b =>
                {
                    b.HasOne("CourseManager.Core.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("CourseManager.Core.Models.File", b =>
                {
                    b.HasOne("CourseManager.Core.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("CourseManager.Core.Models.Grade", b =>
                {
                    b.HasOne("CourseManager.Core.Models.User", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseManager.Core.Models.User", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseManager.Core.Models.Post", b =>
                {
                    b.HasOne("CourseManager.Core.Models.Post", "Parent")
                        .WithMany("Comments")
                        .HasForeignKey("ParentId");

                    b.HasOne("CourseManager.Core.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CourseManager.Core.Models.User", b =>
                {
                    b.HasOne("CourseManager.Core.Models.Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId");
                });
        }
    }
}
