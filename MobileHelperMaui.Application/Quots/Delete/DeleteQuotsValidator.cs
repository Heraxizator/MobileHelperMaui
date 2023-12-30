using MobileHelperMaui.Application.Specifications;
using MobileHelperMaui.Domain.Abstractions.Services;
using MobileHelperMaui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Application.Quots.Delete
{
    public class DeleteQuotsValidator : IValidator<Quot>
    {
        public bool IsValid(Quot value)
        {
            QuotsClearSpecification specification = new();

            bool isOk = specification.IsSatisfiedBy(value);

            return isOk;
        }
    }
}
