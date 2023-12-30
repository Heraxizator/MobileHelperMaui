using Microsoft.EntityFrameworkCore;
using MobileHelperMaui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Abstractions.Database
{
    public interface IApplicationDbContext
    {
        public DbSet<Quot> Quots { get; set; }

        public DbSet<Technique> Techniques { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
