using McsUnaApp.Business.Entities;
using McsUnaApp.Data.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McsUnaApp.Data.Helpers
{
   public class McsUnaDbContext:DbContext
    {
        private string DbConnStr { get; set; }
        public McsUnaDbContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            DbConnStr = root.GetConnectionString("McsUnaDBConn");
        }

        public McsUnaDbContext(DbContextOptions<McsUnaDbContext> options)
         : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           
            optionsBuilder.UseSqlServer(DbConnStr);

        }

        public DbSet<Student> StudentSet { get; set; }
        public DbSet<ResidenceType> ResidenceTypeSet{ get; set; }
        public DbSet<ModeOfTranspot> ModeOfTranspotSet { get; set; }
        public DbSet<StudentVW> StudentVWSet { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ModeOfTranspotConfiguration());
            modelBuilder.ApplyConfiguration(new ResidenceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentVWConfiguration());


        }


    }
}
