using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplikacjaMVC.Models;

namespace AplikacjaMVC.Controllers
{
    public class CarsController : Controller
    {
        private CarDBContext db = new CarDBContext();

        // GET: Cars
        [Authorize(Roles = "Admin, SuperUser, User")]
        public ActionResult Index()
        {
            return View(db.Cars
                .Include(i => i.Seller)
                .Include(i => i.Engine)
                .ToList());
        }

        // GET: Cars/Details/5
        [Authorize(Roles = "Admin, SuperUser, User")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars
                      .Include(i => i.Seller)
                      .Include(i => i.Engine)
                      .SingleOrDefault(x => x.ID == id);

            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Brand,Model,ProductionYear,Color,VIN,Mileage,Photo,Price,Seller,Engine")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars
                      .Include(i => i.Seller)
                      .Include(i => i.Engine)
                      .SingleOrDefault(x => x.ID == id);

            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Brand,Model,ProductionYear,Color,VIN,Mileage,Photo,Price,Seller,Engine")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars
                      .Include(i => i.Seller)
                      .Include(i => i.Engine)
                      .SingleOrDefault(x => x.ID == id);

            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars
                      .Include(i => i.Seller)
                      .Include(i => i.Engine)
                      .SingleOrDefault(x => x.ID == id);
            

            db.Cars.Remove(car);
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
