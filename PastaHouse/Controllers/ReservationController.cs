using PastaHouse.App_Start.CustomAttributes;
using PastaHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PastaHouse.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservation
        [OutputCache(Duration = 300)]
        public ActionResult Index()
        {
            return View();
        }

        // POST: Reservation/ShowAvailableTables
        [HttpPost]
        public PartialViewResult ShowAvailableTables(string date, string time)
        {
            DateTime dateTime = Convert.ToDateTime(date + " " + time);
            var query = (from t in db.Tables
                         where !(from r in db.Reservations
                                 where r.ReservationDateTime == dateTime
                                 select r.TableId).Contains(t.TableId)
                         select t);
            var tables = new List<Table>();
            foreach (var item in query)
            {
                tables.Add(item);
            }
            TempData["dateTime"] = dateTime;
            return PartialView("_AvailableTablesList", tables);
        }

        // GET: Reservation/Reserve/5
        [NoDirectAccess]
        public ActionResult Reserve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = db.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            if (TempData["dateTime"] == null)
            {
                return View("Index");
            }
            Reservation reservation = new Reservation();
            reservation.ReservationDateTime = (DateTime)TempData["dateTime"];
            reservation.TableId = table.TableId;
            reservation.Table = table;
            return View(reservation);
        }

        // POST: Reservation/Reserve/5
        [HttpPost, ActionName("Reserve")]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public ActionResult ReserveConfirmed(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.Table = null;
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return View("ReserveConfirmed", reservation);
            }
            else
            {
                return View("Reserve", reservation);
            }
        }

        // GET: Reservation/Manage
        [CustomAuthorize]
        public ActionResult Manage()
        {
            var reservations = db.Reservations.ToList();
            reservations = reservations.OrderBy(x => x.ReservationDateTime).ToList();
            return View(reservations);
        }

        // GET: Reservation/Delete/5
        [CustomAuthorize]
        [NoDirectAccess]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            var reservations = db.Reservations.ToList();
            return RedirectToAction("Manage", reservations);
        }
    }
}