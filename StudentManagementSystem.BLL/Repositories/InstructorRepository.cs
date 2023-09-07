using InstructorManagementSystem.BLL.Interfaces;
using StudentManagementSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly HttpClient _httpClient;

        public InstructorRepository(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public async Task<IList<Instructor>> GetAllInstructors()
        {
            return await _httpClient.GetFromJsonAsync<List<Instructor>>("getallinstructors");
        }
    }
}
