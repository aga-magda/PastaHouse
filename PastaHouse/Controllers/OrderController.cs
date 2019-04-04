using PastaHouse.App_Start.CustomAttributes;
using PastaHouse.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PastaHouse.Controllers
{
    [NoDirectAccess]
    public class OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Order
        public ActionResult Index()
        {
            if (Session["cart"] != null)
            {
                var client = new Client();
                return View(client);
            }
            else
            {
                return RedirectToAction("Menu", "Home");
            }
        }

        // POST: Order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Client client)
        {
            if (ModelState.IsValid)
            {
                // Redirect to menu page if session is timeout
                if (Session["cart"] == null)
                {
                    return RedirectToAction("Menu", "Home");
                }
                var cart = Session["cart"] as Cart;

                // Assign client and cart to a new order
                var order = new Order();
                order.Cart = cart;
                order.Client = client;
                order.OrderDateTime = DateTime.Now;

                // Saving to database
                db.Orders.Add(order);
                db.SaveChanges();

                // Clear cart when order is complete
                Session["cart"] = null;

                return View("Confirmation", order);
            }
            else
            {
                return View("Index", client);
            }
        }

        // GET: Order/Manage
        [CustomAuthorize]
        public ActionResult Manage()
        {
            var orders = db.Orders.ToList();
            orders = orders.OrderBy(x => x.OrderDateTime)
                           .ToList();
            return View(orders);
        }

        // GET: Order/Deactivate/5
        [CustomAuthorize]
        public ActionResult Deactivate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Deactivate/5
        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public ActionResult DeactivateConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            order.IsActive = false;
            db.SaveChanges();
            var orders = db.Orders.ToList();
            return RedirectToAction("Manage", orders);
        }

        // GET: Order/Delete/5
        [CustomAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            var orders = db.Orders.ToList();
            return RedirectToAction("Manage", orders);
        }


        public ActionResult AddProduct(int id, string name, string category, string subcategory, string ingredients, decimal price)
        {
            var dish = new Dish() { DishId = id, Name = name, Category = category, Subcategory = subcategory, Ingredients = ingredients, Price = price };

            // Read from session and save to it
            Cart cart;
            if (Session["cart"] != null)
            {
                cart = Session["cart"] as Cart;
                // Change cart values
                cart.TotalPrice += dish.Price;
                cart.Dishes.Add(dish);

                // Save to a session
                Session["cart"] = cart;

                return PartialView("_IndexPartial", cart);
            }
            // Return to Menu if session break
            else
            {
                return RedirectToAction("Menu", "Home");
            }
        }

        public ActionResult DeleteProduct(int id)
        {
            // Read from session and save to it
            Cart cart;
            if (Session["cart"] != null)
            {
                cart = Session["cart"] as Cart;

                // Change cart values
                Dish dish;
                dish = cart.Dishes.Find(x => x.DishId == id);
                cart.TotalPrice -= dish.Price;
                cart.Dishes.Remove(dish);

                // Save to a session
                Session["cart"] = cart;

                return PartialView("_IndexPartial", cart);
            }
            // Return to Menu if session break
            else
            {
                return RedirectToAction("Menu", "Home");
            }
        }
    }
}