using MobileHelperMaui.Application.Share;
using MobileHelperMaui.Domain.Abstractions.Database;
using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Abstractions.Services;
using MobileHelperMaui.Domain.Entities;
using MobileHelperMaui.Domain.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileHelperMaui.Application.Quots.Get
{
    public class GetQuotQuery : Share.Query<Quot, Quot>
    {
        public GetQuotQuery(IHandler<Quot, IList<Quot>> handler, IRepository<Quot> repository) : base(handler, repository)
        {
        }
    }
}
