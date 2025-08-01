using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RosondFleetManager.Models;

namespace RosondFleetManager.Controllers
{
    public class VehiclesController : Controller
    {
        private RosondFleetManagerContext db = new RosondFleetManagerContext();

        // GET: Vehicles
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Supplier).Include(v => v.Branch).Include(v => v.Client).Include(v => v.Driver).ToList();
            return View(vehicles);
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Vehicle vehicle = db.Vehicles
                .Include(v => v.Supplier)
                .Include(v => v.Branch)
                .Include(v => v.Client)
                .Include(v => v.Driver)
                .FirstOrDefault(v => v.VehicleId == id);

            if (vehicle == null)
                return HttpNotFound();

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name");
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "Name");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name");
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "Name");
            return View();
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleId,Make,Model,Year,VIN,SupplierId,BranchId,ClientId")] Vehicle vehicle, int? DriverId, string NewDriverName)
        {
            if (string.IsNullOrWhiteSpace(NewDriverName) && DriverId == null)
                ModelState.AddModelError("DriverId", "Please select an existing driver or enter a new driver.");

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(NewDriverName))
                {
                    var newDriver = new Driver { Name = NewDriverName.Trim() };
                    db.Drivers.Add(newDriver);
                    db.SaveChanges();
                    vehicle.DriverId = newDriver.DriverId;
                }
                else if (DriverId.HasValue)
                {
                    vehicle.DriverId = DriverId.Value;
                }

                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", vehicle.SupplierId);
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "Name", vehicle.BranchId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", vehicle.ClientId);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "Name", DriverId);

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
                return HttpNotFound();

            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", vehicle.SupplierId);
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "Name", vehicle.BranchId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", vehicle.ClientId);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "Name", vehicle.DriverId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleId,Make,Model,Year,VIN,SupplierId,BranchId,ClientId")] Vehicle vehicle, int? DriverId, string NewDriverName)
        {
            if (string.IsNullOrWhiteSpace(NewDriverName) && DriverId == null)
                ModelState.AddModelError("DriverId", "Please select an existing driver or enter a new driver.");

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(NewDriverName))
                {
                    var newDriver = new Driver { Name = NewDriverName.Trim() };
                    db.Drivers.Add(newDriver);
                    db.SaveChanges();
                    vehicle.DriverId = newDriver.DriverId;
                }
                else if (DriverId.HasValue)
                {
                    vehicle.DriverId = DriverId.Value;
                }

                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", vehicle.SupplierId);
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "Name", vehicle.BranchId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", vehicle.ClientId);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "Name", DriverId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Vehicle vehicle = db.Vehicles
                .Include(v => v.Supplier)
                .Include(v => v.Branch)
                .Include(v => v.Client)
                .Include(v => v.Driver)
                .FirstOrDefault(v => v.VehicleId == id);

            if (vehicle == null)
                return HttpNotFound();

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
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
