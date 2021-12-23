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
    public class ResidenceTypeConfiguration : IEntityTypeConfiguration<ResidenceType>
    {
   

        public void Configure(EntityTypeBuilder<ResidenceType> builder)
        {
            builder.ToTable("ResidenceTypes");
            builder.HasKey(t => t.ResidenceTypeId);
        }
    }
}
