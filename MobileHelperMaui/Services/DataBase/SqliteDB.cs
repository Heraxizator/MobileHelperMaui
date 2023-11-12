using Microsoft.EntityFrameworkCore;
using MobileHelper.Models.Tables;
using System;
using System.Threading.Tasks;

namespace MobileHelperMaui.Services.DataBase
{
    public class SQLiteDB : DbContext
    {
        #region Tables
        public DbSet<TechniqueDB> Techniques { get; set; }
        public DbSet<QuotDB> Quots { get; set; }

        #endregion

        public string DbPath { get; }

        public SQLiteDB()
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
