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
    public class LookUpRepository : ILookUpRepository
    {
        McsUnaDbContext ctx;
        public LookUpRepository()
        {
            ctx = new McsUnaDbContext();
        }
        public IEnumerable<ModeOfTranspot> GetModeOfTranspots()
        {
            return (from e in ctx.ModeOfTranspotSet
                    select e);
        }

        public IEnumerable<ResidenceType> GetResidenceTypes()
        {
            return (from e in ctx.ResidenceTypeSet
                    select e);
        }
    }
}
