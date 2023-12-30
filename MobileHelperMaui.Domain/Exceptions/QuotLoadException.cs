using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Exceptions
{
    public class QuotLoadException : Exception
    {
        public QuotLoadException(string message) : base(message)
        { 

        }
    }
}
