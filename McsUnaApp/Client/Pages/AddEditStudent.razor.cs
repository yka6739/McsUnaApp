using McsUnaApp.Client.Contracts;
using McsUnaApp.Client.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McsUnaApp.Client.Pages
{
    public partial class AddEditStudent
    {
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        [Inject]
        public IStudentService _studentService { get; set; }

        public Student ObjStudent { get; set; } = new Student();

        public List<ResidenceType> _residenceTypes { get; set; } = new List<ResidenceType>();
        public List<ModeOfTranspot> _modeOfTranspots { get; set; } = new List<ModeOfTranspot>();


        [Parameter]
        public string StudentGuid { get; set; }

        protected async override Task OnInitializedAsync()
        {

            _residenceTypes = (await _studentService.GetResidenceTypes()).ToList();
            _modeOfTranspots = (await _studentService.GetModeOfTranspots()).ToList();


            if (!string.IsNullOrEmpty(StudentGuid)) 
            {
                ObjStudent = await _studentService.GetStudentByGuid(new Guid(StudentGuid));
            }
           // return base.OnInitializedAsync();
        }

        public async Task HandleValidSubmit()
        {
            if (ObjStudent.StudentId == 0) 
            {
                ObjStudent.CreatedDate = DateTime.Now;
                ObjStudent.StudentGuid = Guid.NewGuid();

            }
            ObjStudent.ModifiedDate = DateTime.Now;
            await _studentService.Save(ObjStudent);
            _navigationManager.NavigateTo("/Students");

        }

        public void HandleInvalidSubmit() 
        {
        
        }
        public void OnCancleClick() 
        {
            _navigationManager.NavigateTo("/Students");
        }

    }
}
