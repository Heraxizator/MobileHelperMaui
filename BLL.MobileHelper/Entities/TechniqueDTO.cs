﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MobileHelper.Entities
{
    public class TechniqueDTO
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Theme { get; set; }
        public string Author { get; set; }
        public string Algorithm { get; set; }
        public bool Removed { get; set; }
    }
}
