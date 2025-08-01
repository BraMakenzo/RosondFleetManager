using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosondFleetManager.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}