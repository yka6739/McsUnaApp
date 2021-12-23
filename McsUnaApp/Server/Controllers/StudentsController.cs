using McsUnaApp.Business.Entities;
using McsUnaApp.Data.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McsUnaApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly ILookUpRepository _lookUpRepository;

        public StudentsController(ILogger<StudentsController> logger, IStudentRepository studentRepository,
            ILookUpRepository lookUpRepository
            )
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _lookUpRepository = lookUpRepository;
        }

        [HttpPost("AllStudents")]
        public IEnumerable<StudentVW> AllStudents(StudentSearch filter)
        {
            return _studentRepository.GetVwEntities(filter);
        }

       [HttpPost("SaveStudent")]
        public Student SaveStudent(Student student)
        {
            if (student.StudentId == 0) 
            {
                return _studentRepository.Add(student);
            }
            else 
            {
                return _studentRepository.Update(student);
            }
        }

        [HttpGet("GetStudentByGuid/{studentGuid}")]
        public Student GetStudentByGuid(Guid studentGuid)
        {

            return _studentRepository.Get(studentGuid);

        }



        [HttpGet("RemoveStudent/{studentGuid}")]
        public bool DeleteStudent (Guid studentGuid)
        {
            try
            {
                _studentRepository.Remove(studentGuid);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

            




        }

        [HttpGet("GetResidenceTypes")]

        public IEnumerable<ResidenceType> GetResidenceTypes() 
        {
            return _lookUpRepository.GetResidenceTypes();
        }


        [HttpGet("GetModeOfTranspots")]

        public IEnumerable<ModeOfTranspot> GetModeOfTranspots()
        {
            return _lookUpRepository.GetModeOfTranspots();
        }


    }
}
