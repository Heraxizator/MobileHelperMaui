using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Exceptions.Base
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityMessage)
            : base(entityMessage) 
        {

        }
    }
}
