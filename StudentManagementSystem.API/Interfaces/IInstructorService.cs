using StudentManagementSystem.API.Models;

namespace StudentManagementSystem.API.Interfaces
{
    public interface IInstructorService
    {
        Task<IList<Instructor>> GetAllInstructors();
        Task<Instructor> GetInstructor(int id);
        Task<Instructor> AddInstructor(Instructor newInstructor);
        Task<Instructor> UpdateInstructor(Instructor updatedInstructor);
        Task<Instructor> DeleteInstructor(int id);
    }
}
