using MobileHelperMaui.Domain.Abstractions.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Abstractions
{
    public interface ICommand<Q>
    {
        Task<Q> Execute();
    }
}
