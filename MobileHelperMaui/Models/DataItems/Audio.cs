
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MobileHelper.Models.DataItems
{
    public class Audio
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public bool Loading { get; set; }
        public bool Playing { get; set; }
        public ICommand ClickCommand { get; set; }
    }
}
