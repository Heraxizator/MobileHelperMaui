using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Abstractions
{
    public interface IQuery<Q>
    {
        public Task<IList<Q>> Select();
    }
}
