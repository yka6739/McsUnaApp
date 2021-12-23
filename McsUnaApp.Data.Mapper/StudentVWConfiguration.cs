using McsUnaApp.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McsUnaApp.Data.Mapper
{
    public class StudentVWConfiguration : IEntityTypeConfiguration<StudentVW>
    {
        public void Configure(EntityTypeBuilder<StudentVW> builder)
        {
            builder.ToView("VW_Students");
            builder.HasKey(t => t.StudentId);
        }
    }
}
