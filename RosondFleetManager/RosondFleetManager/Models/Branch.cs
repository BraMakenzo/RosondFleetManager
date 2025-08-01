using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace RosondFleetManager.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
