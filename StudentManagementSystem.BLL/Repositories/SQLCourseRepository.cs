using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.BLL.Interfaces;
using StudentManagementSystem.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Repositories
{
    public class SQLCourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLCourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Course> AddCourse(Course course)
        {
            var newCourse = await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return newCourse.Entity;
        }

        public async Task<Course> DeleteCourse(int id)
        {
            Course course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return null;
            }
            
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<IList<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public Task<Course> GetCourse(int id)
        {
            return _context.Courses.Include(c => c.Enrollments).ThenInclude(e => e.Student).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course> UpdateCourse(Course updatedCourse)
        {
            Course course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == updatedCourse.Id);

            if (course == null)
            {
                return null;
            }
            course.Title = updatedCourse.Title;
            course.Instructor = updatedCourse.Instructor;
            course.Credits = updatedCourse.Credits;

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            return course;
        }
    }
}
