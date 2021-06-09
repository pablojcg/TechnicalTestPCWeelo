using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructure.Entities
{
    public class Property
    {
        public Property()
        {
            PropertyImages = new HashSet<PropertyImage>();
            PropertyTraces = new HashSet<PropertyTrace>();
        }

        [Key]
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public string CodeInternal { get; set; }
        public string Year { get; set; }
        public int IdOwner { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<PropertyImage> PropertyImages { get; set; }
        public virtual ICollection<PropertyTrace> PropertyTraces { get; set; }
    }
}
