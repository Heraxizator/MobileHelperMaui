using DAL.MobileHelper.EF;
using DAL.MobileHelper.Interfaces;
using MobileHelper.Models.Tables;

namespace DAL.MobileHelper.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly SqliteContext db;
        private QuotsRepository quotsRepository;
        private TechniquesRepository techniquesRepository;

        public EFUnitOfWork()
        {
            this.db = new SqliteContext();
        }
        public IRepository<QuotDB> Quots
        {
            get
            {
                this.quotsRepository ??= new QuotsRepository(this.db);
                return this.quotsRepository;
            }
        }

        public IRepository<TechniqueDB> Techniques
        {
            get
            {
                this.techniquesRepository ??= new TechniquesRepository(this.db);
                return this.techniquesRepository;
            }
        }

        public void Save()
        {
            _ = this.db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
