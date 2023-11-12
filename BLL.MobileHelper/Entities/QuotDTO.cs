using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MobileHelper.Entities
{
    public class QuotDTO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public int Frequency { get; set; }
        public bool Removed { get; set; }
    }
}
