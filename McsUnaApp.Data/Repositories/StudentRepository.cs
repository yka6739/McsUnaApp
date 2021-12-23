using McsUnaApp.Business.Entities;
using McsUnaApp.Data.Contracts;
using McsUnaApp.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McsUnaApp.Data.Repositories
{
    public class StudentRepository : McsUnaDbContextNoVwBase<Student,StudentVW>, IStudentRepository
    {
        protected override Student AddEntity(McsUnaDbContext entityContext, Student entity)
        {
            //throw new NotImplementedException();
            return entityContext.StudentSet.Add(entity).Entity;
        }

        protected override IEnumerable<Student> GetEntities(McsUnaDbContext entityContext)
        {
            return (from e in entityContext.StudentSet
                    select e);
        }

        //protected override IEnumerable<Student> GetEntities(McsUnaDbContext entityContext, StudentSearch filter)
        //{
        //    return (from e in entityContext.StudentSet
        //            where e.StudentName == filter.Name
        //            select e);
        //}

        protected override Student GetEntity(McsUnaDbContext entityContext, int id)
        {
            return (from e in entityContext.StudentSet
                    where e.StudentId == id
                    select e).SingleOrDefault();
        }

        protected override Student GetEntity(McsUnaDbContext entityContext, Guid guid)
        {
            return (from e in entityContext.StudentSet
                    where e.StudentGuid == guid
                    select e).FirstOrDefault();
        }

        //protected override Student GetFilteredEntity(McsUnaDbContext entityContext, StudentSearch filter)
        //{
        //    throw new NotImplementedException();
        //}

        protected override IEnumerable<StudentVW> GetViewEntities(McsUnaDbContext entityContext, StudentSearch filter)
        {
            if(!string.IsNullOrEmpty(filter.Name)) 
            {
                return (from e in entityContext.StudentVWSet
                        where e.StudentName.ToLower()==filter.Name.ToLower()
                        select e);
            }

            return (from e in entityContext.StudentVWSet
                    select e);
        }

        protected override StudentVW GetViewEntity(McsUnaDbContext entityContext, StudentSearch filter)
        {
            throw new NotImplementedException();
        }

        protected override StudentVW GetViewEntity(McsUnaDbContext entityContext, int id)
        {
            throw new NotImplementedException();
        }

        protected override StudentVW GetViewEntity(McsUnaDbContext entityContext, Guid guid)
        {
            throw new NotImplementedException();
        }

        protected override Student UpdateEntity(McsUnaDbContext entityContext, Student entity)
        {
            return (from e in entityContext.StudentSet
                    where e.StudentId == entity.StudentId
                    select e).FirstOrDefault();
        }
    }
}
