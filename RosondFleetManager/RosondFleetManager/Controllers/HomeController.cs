using RosondFleetManager.Models;
using System.Linq;
using System.Web.Mvc;

namespace RosondFleetManager.Controllers
{
    public class HomeController : Controller
    {
        private RosondFleetManagerContext db = new RosondFleetManagerContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View(); // Simple About view
        }

        public ActionResult Contact()
        {
            return View(); // Simple Contact view
        }

        public ActionResult Report()
        {
            var viewModel = new ReportViewModel
            {
                VehiclesPerSupplier = db.Vehicles
                    .GroupBy(v => v.Supplier.Name)
                    .Select(g => new ReportItem { Group = g.Key, Count = g.Count() })
                    .ToList(),

                VehiclesPerBranch = db.Vehicles
                    .GroupBy(v => v.Branch.Name)
                    .Select(g => new ReportItem { Group = g.Key, Count = g.Count() })
                    .ToList(),

                VehiclesPerClient = db.Vehicles
                    .GroupBy(v => v.Client.Name)
                    .Select(g => new ReportItem { Group = g.Key, Count = g.Count() })
                    .ToList(),

                VehiclesPerManufacturer = db.Vehicles
                    .GroupBy(v => v.Make)
                    .Select(g => new ReportItem { Group = g.Key, Count = g.Count() })
                    .ToList()
            };

            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}