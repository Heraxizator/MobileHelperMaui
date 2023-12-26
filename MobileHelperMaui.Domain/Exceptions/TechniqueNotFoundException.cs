using MobileHelperMaui.Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Exceptions
{
    public class TechniqueNotFoundException : NotFoundException
    {
        public TechniqueNotFoundException(int techniqueId) 
            : base($"The technique with the identifier {techniqueId} was not found")
        {

        }
    }
}
