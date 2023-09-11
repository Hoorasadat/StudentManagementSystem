using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "Andy",
                    Initials = " A",
                    LastName = " Young",
                    Gender = Gender.Male,
                    ImageFile = "AndyAYoung.jpg",
                    EnrollmentDate = new DateTime(1998, 03, 24)
                },

                new Student()
                {
                    Id = 2,
                    FirstName = "Jane",
                    Initials = " Y",
                    LastName = " Harriman",
                    Gender = Gender.Female,
                    ImageFile = "JaneYHarriman.jpg",
                    EnrollmentDate = new DateTime(2000, 12, 22)
                },

                new Student()
                {
                    Id = 3,
                    FirstName = "kate",
                    Initials = " G",
                    LastName = " George",
                    Gender = Gender.Unknown,
                    ImageFile = "kateGGeorge.jpg",
                    EnrollmentDate = new DateTime(1997, 06, 15)
                },

                new Student()
                {
                    Id = 4,
                    FirstName = "Marc",
                    Initials = " H",
                    LastName = " Bredd",
                    Gender = Gender.Male,
                    ImageFile = "MarcHBredd.jpg",
                    EnrollmentDate = new DateTime(2003, 10, 11)
                }

                );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment() { ID = 1, StudentID = 1, CourseID = 1050, Grade = Grade.A },
                new Enrollment() { ID = 2, StudentID = 1, CourseID = 4022, Grade = Grade.C },
                new Enrollment() { ID = 3, StudentID = 1, CourseID = 4041, Grade = Grade.B },
                new Enrollment() { ID = 4, StudentID = 2, CourseID = 1045, Grade = Grade.B },
                new Enrollment() { ID = 5, StudentID = 2, CourseID = 3141, Grade = Grade.F }, 
                new Enrollment() { ID = 6, StudentID = 2, CourseID = 2021, Grade = Grade.F },
                new Enrollment() { ID = 7, StudentID = 3, CourseID = 1050 },
                new Enrollment() { ID = 8, StudentID = 4, CourseID = 1050 },
                new Enrollment() { ID = 9, StudentID = 4, CourseID = 1050, Grade = Grade.F }
                );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1050, Instructor = "John Dean", Title = "Internet Application 2", Credits = 3 },
                new Course { Id = 4022, Instructor = "David Doe", Title = "Java", Credits = 3 },
                new Course { Id = 4041, Instructor = "Juan Kate", Title = "OOSD", Credits = 3 },
                new Course { Id = 1045, Instructor = "Cheryl Smith", Title = "SQL Server", Credits = 4 },
                new Course { Id = 3141, Instructor = "Alex Byron", Title = "C#", Credits = 3 },
                new Course { Id = 2021, Instructor = "Kate Bill", Title = "Internet Application 1", Credits = 4 },
                new Course { Id = 2042, Instructor = "Fred Mo", Title = "jQuery", Credits = 3 }
                );

            modelBuilder.Entity<Course>().Property(c => c.Id).ValueGeneratedNever();
        }


    }
}
