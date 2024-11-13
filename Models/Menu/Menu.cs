using System.ComponentModel.DataAnnotations;

namespace Labb2RestaurantMVC.Models.Menu
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        public string FoodName { get; set; }

        [Required]
        public string FoodInfo { get; set; }

        [Required]
        public double FoodPrice { get; set; }

        public bool IsPopular { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
