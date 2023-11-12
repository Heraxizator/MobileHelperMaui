using DAL.MobileHelper.EF;
using DAL.MobileHelper.Interfaces;
using MobileHelper.Models.Tables;

namespace DAL.MobileHelper.Repositories
{
    internal class TechniquesRepository : IRepository<TechniqueDB>
    {
        private readonly SqliteContext db;

        public TechniquesRepository(SqliteContext db)
        {
            this.db = db;
        }

        public void Create(TechniqueDB item)
        {
            db.Techniques.Add(item);
        }

        public void Delete(int id)
        {
            TechniqueDB item = this.db.Techniques.Find(id);

            if (item != null)
            {
                _ = this.db.Techniques.Remove(item);
            }
        }

        public IEnumerable<TechniqueDB> Find(Func<TechniqueDB, bool> predicate)
        {
            return db.Techniques.Where(predicate);
        }

        public TechniqueDB Get(int id)
        {
            return this.db.Techniques.Find(id);
        }

        public IEnumerable<TechniqueDB> GetAll()
        {
            return this.db.Techniques;
        }

        public void Update(TechniqueDB item)
        {
            TechniqueDB elem = this.db.Techniques.Find(item.Id);

            if (elem != null)
            {
                _ = this.db.Techniques.Update(item);
            }
        }
    }
}
