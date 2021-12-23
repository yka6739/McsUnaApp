

using McsUnaApp.Client.Contracts;
using McsUnaApp.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McsUnaApp.Client.Services
{
    public class StudentService : IStudentService
    {
        private readonly IHttpService _httpService;

        public StudentService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<bool> DeleteStudent(Guid studentGuid)
        {
            return await _httpService.Get<bool>("api/Students/RemoveStudent/" + studentGuid);
        }

        public async Task<IEnumerable<StudentVW>> GetAllStudents(StudentSearch filter)
        {
            return await _httpService.GetFilteredEntities<StudentVW>("api/Students/AllStudents", filter);
        }

        public async Task<IEnumerable<ModeOfTranspot>> GetModeOfTranspots()
        {
            return await _httpService.GetEntities<ModeOfTranspot>("api/Students/GetModeOfTranspots");
        }

        public Task<IEnumerable<ResidenceType>> GetResidenceTypes()
        {
            return _httpService.GetEntities<ResidenceType>("api/Students/GetResidenceTypes");
        }

        public async Task<Student> GetStudentByGuid(Guid studentGuid)
        {
            return await _httpService.Get<Student>("api/Students/GetStudentByGuid/"+studentGuid); 
        }

        public async Task<Student> Save(Student student)
        {
            return await _httpService.Post<Student>("api/Students/SaveStudent", student);
        }
    }
}
