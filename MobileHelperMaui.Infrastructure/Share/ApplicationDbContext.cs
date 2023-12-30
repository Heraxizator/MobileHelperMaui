using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MobileHelperMaui.Domain.Abstractions.Database;
using MobileHelperMaui.Domain.Entities;

namespace MobileHelperMaui.Infrastructure.Share
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
    {
        private readonly string DbPath;

        public DbSet<Quot> Quots { get; set; }
        public DbSet<Technique> Techniques { get; set; }

        public ApplicationDbContext()
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "local.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            _ = options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
