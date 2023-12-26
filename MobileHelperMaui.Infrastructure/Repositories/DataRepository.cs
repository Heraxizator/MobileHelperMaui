using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Infrastructure.Share;

namespace MobileHelperMaui.Infrastructure.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly ApplicationDbContext _context = new();
        public IQuotRepository GetQuotRepository()
        {
            return new QuotRepository(this._context);
        }

        public ITechniqueRepository GetTechniqueRepository()
        {
            return new TechniqueRepository(this._context);
        }
    }
}
