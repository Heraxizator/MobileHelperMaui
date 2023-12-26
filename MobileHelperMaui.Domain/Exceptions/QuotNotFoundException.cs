using MobileHelperMaui.Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Exceptions
{
    public sealed class QuotNotFoundException : NotFoundException
    {
        public QuotNotFoundException(int quotId) 
            : base($"Quot with the identifier {quotId} was not found")
        {
        }
    }
}
