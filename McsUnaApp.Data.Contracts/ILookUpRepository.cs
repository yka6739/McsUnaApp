using McsUnaApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McsUnaApp.Data.Contracts
{
   public interface ILookUpRepository
    {
        IEnumerable<ResidenceType> GetResidenceTypes();
        IEnumerable<ModeOfTranspot> GetModeOfTranspots();
    }
}
