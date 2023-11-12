using MobileHelper.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MobileHelper.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<QuotDB> Quots { get; }
        IRepository<TechniqueDB> Techniques { get; }
        void Save();
    }
}
