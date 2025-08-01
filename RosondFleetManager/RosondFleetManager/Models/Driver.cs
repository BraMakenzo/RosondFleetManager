using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RosondFleetManager.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
