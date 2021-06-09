using System;
using System.Collections.Generic;
using System.Text;
using Infraestructure.Entities;

namespace Domain.PocoClass
{
    public class TotalConsult
    {
        public Owner OwnerData { get; set; }
        public Property PropertyData { get; set; }
        public PropertyImage PropertyImageData { get; set; }
        public PropertyTrace PropertyTraceData { get; set; }
    }
}
