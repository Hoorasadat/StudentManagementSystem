using StudentManagementSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Interfaces
{
    public interface IStudentRepository
    {
        Task<IList<Student>> GetAllStudents();
        Task<Student> GetStudent(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);

        Task<IList<string>> GetStudentCourses(int id);
        Task<Student> DeleteStudent(int id);

    }
}
