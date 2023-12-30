using MobileHelperMaui.Application.Specifications;
using MobileHelperMaui.Domain.Abstractions.Database;
using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Abstractions.Services;
using MobileHelperMaui.Domain.Entities;
using MobileHelperMaui.Domain.Share;

namespace MobileHelperMaui.Application.Quots.Get
{
    public class GetQuotHandler : IHandler<Quot, IList<Quot>>
    {
        public async Task<IList<Quot>> Handle(IRepository<Quot> repository)
        {
            QuotSearchSpecification specification = new();

            GetQuotValidator validator = new();

            IList<Quot> list = await Task.Run(
                async () => (await repository.GetAll()).Where(x => validator.IsValid(x)).ToList());

            return list;
        }
    }
}
