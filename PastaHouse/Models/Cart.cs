using System.Collections.Generic;

namespace PastaHouse.Models
{
    public class Cart
    {
        public Cart()
        {
            Dishes = new List<Dish>();
        }

        public int CartId { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual List<Dish> Dishes { get; set; }
    }
}