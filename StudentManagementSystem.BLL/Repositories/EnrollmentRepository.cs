using EnrollmentManagementSystem.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        public Task<Enrollment> AddEnrollment(Enrollment Enrollment)
        {
            throw new NotImplementedException();
        }

        public Task<Enrollment> DeleteEnrollment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Enrollment>> GetAllEnrollments()
        {
            throw new NotImplementedException();
        }

        public Task<Enrollment> GetEnrollment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Enrollment> UpdateEnrollment(Enrollment Enrollment)
        {
            throw new NotImplementedException();
        }
    }
}
