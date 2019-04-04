namespace PastaHouse.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }
    }
}