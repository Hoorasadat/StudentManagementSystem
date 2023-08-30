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
        Task<Enrollment> AddEnrollment(Enrollment Enrollment);
        Task<Enrollment> UpdateEnrollment(Enrollment Enrollment);
        Task<Enrollment> DeleteEnrollment(int id);
    }
}
