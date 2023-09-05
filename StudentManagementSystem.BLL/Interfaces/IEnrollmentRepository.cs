using StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentManagementSystem.BLL.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IList<Enrollment>> GetAllEnrollments();
        Task<Enrollment> GetEnrollment(int id);
        Task<Enrollment> AddEnrollment(Enrollment newEnrollment);
        Task<Enrollment> UpdateEnrollment(Enrollment updatedEnrollment);
        Task<Enrollment> DeleteEnrollment(int id);
    }
}
