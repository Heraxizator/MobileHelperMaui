using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MobileHelper.Models.Items
{
    public class TechniqueItem
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Theme { get; set; }
        public string Author { get; set; }
        public bool Active { get; set; }
        public ICommand TapCommand { get; set; }

    }
}
