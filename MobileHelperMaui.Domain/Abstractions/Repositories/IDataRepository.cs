using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Abstractions.Repositories
{
    public interface IDataRepository
    {
        IQuotRepository GetQuotRepository();
        ITechniqueRepository GetTechniqueRepository();
    }
}
