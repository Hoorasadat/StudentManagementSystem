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
        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course updatedCourse);
        Task<Course> DeleteCourse(int id);
    }
}
