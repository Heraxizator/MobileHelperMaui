using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Exceptions.Base
{
    public class UnsupportedException : Exception
    {
        public UnsupportedException(string message) : base(message) 
        { 

        }
    }
}
