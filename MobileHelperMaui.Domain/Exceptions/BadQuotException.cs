using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Exceptions
{
    public class BadQuotException : Exception
    {
        public BadQuotException(string message) : base(message)
        { 
        }
    }
}
