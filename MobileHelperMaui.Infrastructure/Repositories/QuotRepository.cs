using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Entities;
using MobileHelperMaui.Domain.Exceptions;
using MobileHelperMaui.Infrastructure.Share;

namespace MobileHelperMaui.Infrastructure.Repositories
{
    public class QuotRepository : IRepository<Quot>
    {
        private readonly ApplicationDbContext _dbContext;

        public QuotRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Delete(Quot quot)
        {
            this._dbContext.Remove(quot);

            this._dbContext.SaveChanges();
        }

        public async Task<IList<Quot>> GetAll()
        {
            IList<Quot> list = await Task.Run(() => this._dbContext.Quots.Where(x => x.Removed == false).ToList());

            return list;
        }

        public async Task<Quot> GetById(int id)
        {
            Quot quot = await Task.Run(() => this._dbContext.Quots.FirstOrDefault(x => x.Id == id && x.Removed == false));

            return quot is null ? throw new QuotNotFoundException(id) : quot;
        }

        public void Insert(Quot quot)
        {
            this._dbContext.Add(quot);

            this._dbContext.SaveChanges();
        }

        public void Update(Quot item)
        {
            this._dbContext.Update(item);

            this._dbContext.SaveChanges();
        }
    }
}
