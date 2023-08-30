using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Interfaces
{
    public interface ICourseRepository
    {
        Task<IList<Course>> GetAllCourses();
        Task<Course> GetCourse(int id);
        Task<Course> AddCourse(Course Course);
        Task<Course> UpdateCourse(Course Course);
        Task<Course> DeleteCourse(int id);
    }
}
