using MobileHelperMaui.Application.Share;
using MobileHelperMaui.Domain.Abstractions;
using MobileHelperMaui.Domain.Abstractions.Database;
using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Abstractions.Services;
using MobileHelperMaui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Application.Quots.CreateQuot
{
    public class CreateQuotCommand : Share.Command<Quot, bool>
    {
        public CreateQuotCommand(IHandler<Quot, bool> handler, IRepository<Quot> repository) : base(handler, repository)
        {

        }
    }
}
