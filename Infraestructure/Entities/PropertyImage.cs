using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructure.Entities
{
    public class PropertyImage
    {
        [Key]
        public int IdPropertyImage { get; set; }
        public string file { get; set; }
        public bool Enabled { get; set; }
        public int IdProperty { get; set; }
        public virtual Property Property { get; set; }
    }
}
