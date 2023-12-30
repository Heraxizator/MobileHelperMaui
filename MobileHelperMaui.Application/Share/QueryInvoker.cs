using MobileHelperMaui.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Application.Share
{
    public class QueryInvoker<Q>
    {
        private IQuery<Q> query;

        public QueryInvoker()
        {

        }

        public void SetQuery(IQuery<Q> query)
        {
            this.query = query;
        }

        public async Task<IList<Q>> Run()
        {
            IList<Q> result = await this.query.Select();

            return result;
        }
    }
}
