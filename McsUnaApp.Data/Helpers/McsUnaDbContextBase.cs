using Core.Common.Data;
using McsUnaApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McsUnaApp.Data.Helpers
{


    //public abstract class McsUnaDbContextBase<T, VW> : CoreRepository<T, VW, StudentSearch, McsUnaDbContext>
    //   where T : class, new()
    //   where VW : class, new()
    //{

    //}

    public abstract class McsUnaDbContextNoVwBase<T,VW> : CoreRepository<T,VW, StudentSearch, McsUnaDbContext>
       where T : class, new()
       where VW : class, new()

    {

    }

}
