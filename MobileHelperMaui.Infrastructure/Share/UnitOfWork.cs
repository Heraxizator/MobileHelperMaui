using MobileHelperMaui.Domain.Abstractions.Database;
using MobileHelperMaui.Infrastructure.Repositories;

namespace MobileHelperMaui.Infrastructure.Share
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext = new();

        private QuotRepository quotRepository;
        private TechniqueRepository techniqueRepository;

        public QuotRepository QuotRepository
        {
            get
            {
                this.quotRepository ??= new QuotRepository(this._dbContext);

                return this.quotRepository;
            }
        }

        public TechniqueRepository TechniqueRepository
        {
            get
            {
                this.techniqueRepository ??= new TechniqueRepository(this._dbContext);

                return this.techniqueRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            this._dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
