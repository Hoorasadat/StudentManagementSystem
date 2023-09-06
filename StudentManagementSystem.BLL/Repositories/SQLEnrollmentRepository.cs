using EnrollmentManagementSystem.BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data.Data;
using StudentManagementSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Repositories
{
    public class SQLEnrollmentRepository : IEnrollmentRepository
    {

        private readonly ApplicationDbContext _context;

        public SQLEnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Enrollment> AddEnrollment(Enrollment newEnrollment)
        {
            var enrollment = await _context.Enrollments.AddAsync(newEnrollment);
            await _context.SaveChangesAsync();

            return enrollment.Entity;
        }

        public async Task<Enrollment> DeleteEnrollment(int id)
        {
            Enrollment enrollment = await _context.Enrollments.FirstOrDefaultAsync(x => x.ID == id);

            if (enrollment == null)
            {
                return null;
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return enrollment;
        }

        public async Task<IList<CourseEnrollmentCount>> CourseEnrollmentCount()
        {
            return await _context.Enrollments.GroupBy(e => e.Course.Title).Select(c => new CourseEnrollmentCount()
            {
                CourseTitle = c.Key,
                NumberOfStudents = c.Count()
            }).ToListAsync();
        }

        public async Task<IList<Enrollment>> GetAllEnrollments()
        {
            return await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).ToListAsync();
        }

        public async Task<Enrollment> GetEnrollment(int id)
        {
            return await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task<Enrollment> UpdateEnrollment(Enrollment updatedEnrollment)
        {
            Enrollment enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.ID == updatedEnrollment.ID);

            if (enrollment == null)
            {
                return null;
            }

            enrollment.StudentID = updatedEnrollment.StudentID;
            enrollment.CourseID = updatedEnrollment.CourseID;
            enrollment.Grade = updatedEnrollment.Grade;

            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();

            return enrollment;
        }
    }
}
