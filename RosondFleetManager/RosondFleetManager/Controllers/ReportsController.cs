using RosondFleetManager.Models;
using System.Linq;
using System.Web.Mvc;

namespace RosondFleetManager.Controllers
{
    public class ReportsController : Controller
    {
        private RosondFleetManagerContext db = new RosondFleetManagerContext();

        public ActionResult Index()
        {
            var report = new ReportViewModel
            {
                VehiclesPerSupplier = db.Vehicles
                    .GroupBy(v => v.Supplier.Name)
                    .Select(g => new ReportItem
                    {
                        Group = g.Key,
                        Count = g.Count()
                    }).ToList(),

                VehiclesPerBranch = db.Vehicles
                    .GroupBy(v => v.Branch.Name)
                    .Select(g => new ReportItem
                    {
                        Group = g.Key,
                        Count = g.Count()
                    }).ToList(),

                VehiclesPerClient = db.Vehicles
                    .GroupBy(v => v.Client.Name)
                    .Select(g => new ReportItem
                    {
                        Group = g.Key,
                        Count = g.Count()
                    }).ToList(),

                VehiclesPerManufacturer = db.Vehicles
                    .GroupBy(v => v.Make)
                    .Select(g => new ReportItem
                    {
                        Group = g.Key,
                        Count = g.Count()
                    }).ToList()
            };

            return View(report);
        }
    }
}
