using StudentManagementSystem.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public Task<Course> AddCourse(Course Course)
        {
            throw new NotImplementedException();
        }

        public Task<Course> DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Course>> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> UpdateCourse(Course Course)
        {
            throw new NotImplementedException();
        }
    }
}
