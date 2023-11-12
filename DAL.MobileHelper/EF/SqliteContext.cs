using Microsoft.EntityFrameworkCore;
using MobileHelper.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MobileHelper.EF
{
    public class SqliteContext : DbContext
    {
        #region Tables
        public DbSet<TechniqueDB> Techniques { get; set; }
        public DbSet<QuotDB> Quots { get; set; }

        #endregion

        public string DbPath { get; }

        public SqliteContext()
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            this.DbPath = System.IO.Path.Join(path, "mobile.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            _ = options.UseSqlite($"Data Source={this.DbPath}");
        }
    }
    }
}
