using MobileHelperMaui.Domain.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Entities
{
    public sealed class Quot : Entity
    {

        public Quot(int id, string author, string text, bool removed) : base(id)
        {
            this.Author = author;
            this.Text = text;
            this.Removed = removed;
        }

        public Quot() 
        { 

        }

        public string Author { get; set; }
        public string Text { get; set; }
        public bool Removed { get; set; }
    }
}
