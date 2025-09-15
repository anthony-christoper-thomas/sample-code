using CarrierApplication1.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace CarrierApplication1.Controllers
{
    public class CarrierController : Controller
    {
        private CarrierRepository repo = new CarrierRepository();

        private DevEntities db = new DevEntities();

        // GET: Carriers
        public ActionResult Index()
        {
            return View(repo.GetCarriers().ToList());
        }

        // GET: Carriers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carriers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CarrierName,Address,Address2,City,State,Zip,Zip2,Contact,Phone,Fax,Email")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                repo.AddCarrier(carrier);
                return RedirectToAction("Index");
            }

            return View(carrier);
        }

        // GET: Carriers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrierView carrier = repo.FindCarrier(id.Value);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // POST: Carriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrier carrier = db.Carriers.Find(id);
            db.Carriers.Remove(carrier);
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
