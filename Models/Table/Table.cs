using System.ComponentModel.DataAnnotations;

namespace Labb2RestaurantMVC.Models.Table
{
    public class Table
    {
        public int Id { get; set; }

        public int TableSeats { get; set; }

        public int TableNumber { get; set; }
    }
}
