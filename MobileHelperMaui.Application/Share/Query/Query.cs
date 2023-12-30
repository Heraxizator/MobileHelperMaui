using MobileHelperMaui.Domain.Abstractions;
using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Application.Share.Query
{
    public class Query<T, Q> : IQuery<Q>
    {
        private readonly IHandler<T, IList<Q>> handler;
        private readonly IRepository<T> repository;

        public Query(IHandler<T, IList<Q>> handler, IRepository<T> repository)
        {
            this.handler = handler;
            this.repository = repository;
        }

        public async Task<IList<Q>> Select()
        {
            IList<Q> result = await handler.Handle(repository);

            return result;
        }
    }
}
