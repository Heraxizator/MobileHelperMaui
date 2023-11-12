using DAL.MobileHelper.EF;
using DAL.MobileHelper.Interfaces;
using MobileHelper.Models.Tables;

namespace DAL.MobileHelper.Repositories
{
    public class QuotsRepository : IRepository<QuotDB>
    {
        private readonly SqliteContext db;
        public QuotsRepository(SqliteContext context)
        {
            this.db = context;
        }

        public void Create(QuotDB item)
        {
            _ = this.db.Quots.Add(item);
        }

        public void Delete(int id)
        {
            QuotDB item = this.db.Quots.Find(id);

            if (item != null)
            {
                _ = this.db.Quots.Remove(item);
            }
        }

        public IEnumerable<QuotDB> Find(Func<QuotDB, bool> predicate)
        {
            return db.Quots.Where(predicate);
        }

        public QuotDB Get(int id)
        {
            return db.Quots.Find(id);
        }

        public IEnumerable<QuotDB> GetAll()
        {
            return db.Quots;
        }

        public void Update(QuotDB item)
        {
            QuotDB elem = this.db.Quots.Find(item.Id);

            if (elem != null)
            {
                _ = this.db.Quots.Remove(item);
            }
        }
    }
}
