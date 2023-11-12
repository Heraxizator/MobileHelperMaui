using BLL.MobileHelper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MobileHelper.Interfaces
{
    public interface IQuotsService
    {
        void MakeQuot(QuotDTO quot);
        IEnumerable<QuotDTO> GetLFUQuots(int count);
        void UpdateFrequency(IEnumerable<QuotDTO> quots);
        void Dispose();
    }
}
