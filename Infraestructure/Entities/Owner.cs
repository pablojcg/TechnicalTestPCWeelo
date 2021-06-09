using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructure.Entities
{
    public class Owner
    {
        public Owner()
        {
            Propertys = new HashSet<Property>();
        }

        [Key]
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public virtual ICollection<Property> Propertys { get; set; }
    }
}
