using MobileHelperMaui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Abstractions.Repositories
{
    public interface IDataRepository
    {
        IRepository<Quot> GetQuotRepository();
        IRepository<Technique> GetTechniqueRepository();
    }
}
