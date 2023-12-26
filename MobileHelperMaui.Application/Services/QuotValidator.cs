using FluentValidation;
using MobileHelperMaui.Application.Specifications;
using MobileHelperMaui.Domain.Abstractions;
using MobileHelperMaui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Application.Services
{
    public class QuotValidator : Domain.Abstractions.Services.IValidator<Quot>
    {
        public bool IsValid(Quot value)
        {
            Specification<Quot> specification = new QuotValidateSpecification();

            bool isOk = specification.IsSatisfiedBy(value);

            return isOk;
        }
    }
}
