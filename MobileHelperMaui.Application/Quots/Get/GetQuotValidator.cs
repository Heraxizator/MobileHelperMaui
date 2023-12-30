using MobileHelperMaui.Application.Specifications;
using MobileHelperMaui.Domain.Abstractions.Services;
using MobileHelperMaui.Domain.Entities;

namespace MobileHelperMaui.Application.Quots.Get
{
    public class GetQuotValidator : IValidator<Quot>
    {
        public bool IsValid(Quot value)
        {
            QuotSearchSpecification specification = new();

            bool isOk = specification.IsSatisfiedBy(value);

            return isOk;
        }
    }
}
