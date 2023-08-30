﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StudentManagementSystem.BLL.Interfaces;
using StudentManagementSystem.Data.Data;
using StudentManagementSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Repositories
{
    public class MockStudentRepository : IStudentRepository
    {
        private readonly MemoryDbContext _context;
        public MockStudentRepository(MemoryDbContext context) 
        { 
            _context = context;
        }
        public Task<Student> AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<Student> DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Student>> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        private async Task SeedData()
        {
            if (!_context.Students.Any())
            {
                Student s1 = new Student()
                {
                    Id = 1,
                    FirstName = "Andy",
                    LastName = " Young",
                    Gender = Gender.Male,
                    ImageFile = "AndyYoung.jpg",
                    EnrollmentDate = new DateTime(1998, 03, 24)
                };

                Student s2 = new Student()
                {
                    Id = 2,
                    FirstName = "Jane",
                    Initials = " Y",
                    LastName = " Harriman",
                    Gender = Gender.Female,
                    ImageFile = "JaneYHarriman.jpg",
                    EnrollmentDate = new DateTime(2000, 12, 22)
                };

                Student s3 = new Student()
                {
                    Id = 3,
                    FirstName = "kate",
                    Initials = " G",
                    LastName = " George",
                    Gender = Gender.Unknown,
                    ImageFile = "kateGGeorge.jpg",
                    EnrollmentDate = new DateTime(1997, 06, 15)
                };

                Student s4 = new Student()
                {
                    Id = 4,
                    FirstName = "Marc",
                    Initials = " H",
                    LastName = " Bredd",
                    Gender = Gender.Male,
                    ImageFile = "MarcBredd.jpg",
                    EnrollmentDate = new DateTime(2003, 10, 11)
                };

                await _context.Students.AddRangeAsync(s1, s2, s3, s4);
            }
        }
    }
}
