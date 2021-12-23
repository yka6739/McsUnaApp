using McsUnaApp.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McsUnaApp.Client.Contracts
{
   public interface IStudentService
    {
        Task<IEnumerable<StudentVW>> GetAllStudents(StudentSearch filter);
        Task<Student> Save(Student student);
        Task<Student> GetStudentByGuid(Guid studentGuid);
        Task<bool> DeleteStudent(Guid studentGuid);

        Task<IEnumerable<ResidenceType>> GetResidenceTypes();

        Task<IEnumerable<ModeOfTranspot>> GetModeOfTranspots();

    }
}
