using MobileHelperMaui.Domain.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Entities
{
    public sealed class Technique : Entity
    {
        public Technique(int id, DateTime createdDate, string imageLink, 
            string imageTitle, string imageSubtitle, string imageTheme, 
            string imageAuthor, string imageAlgorithm) : base(id)
        {
            this.Date = createdDate;
            this.Image = imageLink;
            this.Title = imageTitle;
            this.Subtitle = imageSubtitle;
            this.Theme = imageTheme;
            this.Author = imageAuthor;
            this.Algorithm = imageAlgorithm;
        }

        public Technique() { }

        public DateTime Date { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Theme { get; set; }
        public string Author { get; set; }
        public string Algorithm { get; set; }
        public bool Removed { get; set; }
    }
}
