using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McsUnaApp.Business.Entities
{
   public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? AdmissionNo { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int? ResidenceTypeId { get; set; }

        public int? ModeOfTransportId { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? StudentGuid { get; set; }
    }
}
