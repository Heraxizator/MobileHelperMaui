
using MobileHelperMaui.Application.API;
using MobileHelperMaui.Application.Exceptions;
using MobileHelperMaui.Application.Services;
using MobileHelperMaui.Domain.Abstractions.Services;
using MobileHelperMaui.Domain.Entities;

namespace MobileHelperMaui.Application.Handlers
{
    public class QuotHandler : IHandler<Quot>
    {
        public async Task<Quot> Handle()
        {
            ILoader<Quot> manager = new QuotLoader();

            Quot quot = await manager.Load();

            IValidator<Quot> validator = new QuotValidator();

            bool isOk = validator.IsValid(quot);

            return !isOk ? throw new BadQuotException("The quot failed one or more requirements") : quot;
        }
    }
}
