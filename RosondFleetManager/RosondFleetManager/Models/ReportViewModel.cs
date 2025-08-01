using System.Collections.Generic;

namespace RosondFleetManager.Models
{
    public class ReportItem
    {
        public string Group { get; set; }
        public int Count { get; set; }
    }

    public class ReportViewModel
    {
        public List<ReportItem> VehiclesPerSupplier { get; set; }
        public List<ReportItem> VehiclesPerBranch { get; set; }
        public List<ReportItem> VehiclesPerClient { get; set; }
        public List<ReportItem> VehiclesPerManufacturer { get; set; }
    }
}
