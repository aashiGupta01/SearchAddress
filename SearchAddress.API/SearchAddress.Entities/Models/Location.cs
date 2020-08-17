using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAddress.Entities.Models
{
   public class Location
    {
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }

    }
}
