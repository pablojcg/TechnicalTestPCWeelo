using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructure.Entities
{
    public class PropertyTrace
    {
        [Key]
        public int IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        public int IdProperty { get; set; }
        public virtual Property Property { get; set; }
    }
}
