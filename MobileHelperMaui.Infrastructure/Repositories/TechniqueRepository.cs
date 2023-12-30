using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Entities;
using MobileHelperMaui.Domain.Exceptions;
using MobileHelperMaui.Infrastructure.Share;

namespace MobileHelperMaui.Infrastructure.Repositories
{
    public class TechniqueRepository : IRepository<Technique>
    {
        private readonly ApplicationDbContext _dbContext;

        public TechniqueRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Delete(Technique technique)
        {
            this._dbContext.Remove(technique);

            this._dbContext.SaveChanges();
        }

        public async Task<IList<Technique>> GetAll()
        {
            IList<Technique> list = await Task.Run(() => this._dbContext.Techniques.Where(x => x.Removed == false).ToList());

            return list;
        }

        public async Task<Technique> GetById(int id)
        {
            Technique technique = await Task.Run(() => this._dbContext.Techniques.FirstOrDefault(x => x.Id == id && x.Removed == false));

            return technique is null ? throw new TechniqueNotFoundException(id) : technique;
        }

        public void Insert(Technique technique)
        {
            this._dbContext.Add(technique);

            this._dbContext.SaveChanges();
        }

        public void Update(Technique technique)
        {
            this._dbContext.Update(technique);

            this._dbContext.SaveChanges();
        }
    }
}
