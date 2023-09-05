using Microsoft.EntityFrameworkCore;
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
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLStudentRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }
        
        public async Task<Student> AddStudent(Student student)
        {
            var newStudent = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return newStudent.Entity;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            Student student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<IList<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<string>> GetStudentCourses(int id)
        {
            IList<string> CourseList = new List<string>();
            
            if (id == 1)
            {
                CourseList = new List<string>() { "ASP.NET Core", "SQL Server" };
            } 
            else if (id == 2)
            {
                CourseList = new List<string>() { "ASP.NET Core", "C# .NET", "SQL Server" };
            }
            else if (id == 3)
            {
                CourseList = new List<string>() { "ASP.NET Core", "C# .NET", "Entity Framework core" };
            }
            else
            {
                CourseList = new List<string>() { "BootStrap", "JQuery", "Angular JS" };
            }

            return CourseList;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            Student studentToUpdate = await _context.Students.FirstOrDefaultAsync(x => x.Id == student.Id);
            
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.Initials = student.Initials;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.Gender = student.Gender;
            studentToUpdate.ImageFile = student.ImageFile;
            studentToUpdate.EnrollmentDate = student.EnrollmentDate;

            _context.Students.Update(studentToUpdate);
            _context.SaveChanges();
            return studentToUpdate;
        }
    }
}
