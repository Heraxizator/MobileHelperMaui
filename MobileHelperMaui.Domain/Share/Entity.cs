using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Share
{
    public abstract class Entity
    {
        public Entity() { }

        public Entity(int id) 
        { 
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
