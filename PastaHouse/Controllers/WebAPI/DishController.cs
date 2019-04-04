using PastaHouse.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PastaHouse.Controllers.WebAPI
{
    public class DishController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/dish
        public IEnumerable<Dish> Get()
        {
            return db.Dishes.ToList();
        }

        // GET api/dish/5
        public Dish Get(int id)
        {
            return db.Dishes.FirstOrDefault(d => d.DishId == id);
        }
    }
}