using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Entities;
using MobileHelperMaui.Infrastructure.Share;

namespace MobileHelperMaui.Infrastructure.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly ApplicationDbContext _context = new();
        public IRepository<Quot> GetQuotRepository()
        {
            return new QuotRepository(this._context);
        }

        public IRepository<Technique> GetTechniqueRepository()
        {
            return new TechniqueRepository(this._context);
        }
    }
}
