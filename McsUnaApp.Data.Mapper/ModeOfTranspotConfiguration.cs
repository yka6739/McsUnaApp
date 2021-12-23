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
    public class ModeOfTranspotConfiguration : IEntityTypeConfiguration<ModeOfTranspot>
    {
        public void Configure(EntityTypeBuilder<ModeOfTranspot> builder)
        {
           builder.ToTable("ModeOfTranspots");
            builder.HasKey(t => t.ModeOfTransportId);
        }
    }
}
