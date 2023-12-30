using MobileHelperMaui.Domain.Abstractions.Database;
using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Abstractions.Services;
using MobileHelperMaui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Application.Quots.Delete
{
    public class DeleteQuotsHandler : IHandler<Quot, bool>
    {
        public async Task<bool> Handle(IRepository<Quot> repository)
        {
            IList<Quot> list = await Task.Run(() => repository.GetAll());

            foreach (Quot quot in list)
            {
                repository.Delete(quot);
            }

            return true;
        }
    }
}
