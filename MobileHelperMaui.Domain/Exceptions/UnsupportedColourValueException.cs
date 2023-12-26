using MobileHelperMaui.Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Exceptions
{
    public class UnsupportedColourValueException : UnsupportedException
    {
        public UnsupportedColourValueException(string message) : base(message)
        {
        }
    }
}
