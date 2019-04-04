using PastaHouse.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Runtime.Caching;
using System;

namespace PastaHouse.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [OutputCache(Duration = 300)]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 300)]
        [Route("About")]
        public ActionResult About()
        {
            return View();
        }

        [OutputCache(Duration = 300)]
        [Route("Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("Menu")]
        public ActionResult Menu()
        {
            var cache = MemoryCache.Default;
            if (cache["dishes"] == null)
            {
                var dishes = db.Dishes;
                cache.Add("dishes", dishes, DateTime.Now.AddMinutes(3));
            }
            return View(cache["dishes"]);
        }

        public PartialViewResult AddProduct(int id, string name, string category, string subcategory, string ingredients, decimal price)
        {
            var dish = new Dish() { DishId = id, Name = name, Category = category, Subcategory = subcategory, Ingredients = ingredients, Price = price };

            // Read from session
            Cart cart;
            if (Session["cart"] != null)
                cart = Session["cart"] as Cart;
            else
                cart = new Cart();

            // Change cart values
            cart.TotalPrice += dish.Price;
            cart.Dishes.Add(dish);

            // Save to a session
            Session["cart"] = cart;

            return PartialView("_MenuCart", cart);
        }

        public PartialViewResult DeleteProduct(int id)
        {
            // Read from session
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
            }
            else
                cart = new Cart();

            return PartialView("_MenuCart", cart);
        }

        public ActionResult GetNumberOfDishes(int id)
        {
            // Read from session
            Cart cart;
            int numberOfDishes = 0;
            if (Session["cart"] != null)
            {
                cart = Session["cart"] as Cart;
                // Read amount of dishes
                List<Dish> dishes;
                dishes = cart.Dishes.FindAll(x => x.DishId == id);
                numberOfDishes = dishes.Count;
            }
            else
                cart = new Cart();

            return Json(new { num = numberOfDishes }, JsonRequestBehavior.AllowGet);
        }


        public PartialViewResult ClearCart()
        {
            //Clear session
            Session["cart"] = null;
            var cart = new Cart();

            return PartialView("_MenuCart", cart);
        }
    }
}