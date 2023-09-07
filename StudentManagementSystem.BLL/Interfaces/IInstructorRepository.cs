using StudentManagementSystem.Lib.Models;

namespace InstructorManagementSystem.BLL.Interfaces
{
    public interface IInstructorRepository
    {
        Task<IList<Instructor>> GetAllInstructors();
    }
}
