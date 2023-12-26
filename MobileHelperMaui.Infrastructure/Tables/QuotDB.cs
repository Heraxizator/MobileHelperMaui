using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MobileHelper.Models.Tables
{
    public class QuotDB
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public bool Removed { get; set; }
    }
}
