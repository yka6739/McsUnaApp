using McsUnaApp.Client.Contracts;
using McsUnaApp.Client.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McsUnaApp.Client.Pages
{
    public partial class StudentList
    {
        [Inject]
        public IStudentService _StudentService { get; set; }
        public List<StudentVW> AllStudents { get; set; } = new List<StudentVW>();
        public StudentSearch _filter { get; set; }=new StudentSearch();

        protected async override Task OnInitializedAsync()
        {
            AllStudents = (await _StudentService.GetAllStudents(_filter)).ToList();
        }



        public async Task DeleateStudent(Guid? studentguid)
        {
          await _StudentService.DeleteStudent((Guid)studentguid);
         AllStudents = (await _StudentService.GetAllStudents(_filter)).ToList();
        }

        public async Task OnSearch() 
        {
            AllStudents = (await _StudentService.GetAllStudents(_filter)).ToList();
        }

    }
}
