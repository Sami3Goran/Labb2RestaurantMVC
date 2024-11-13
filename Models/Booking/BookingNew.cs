using System.ComponentModel.DataAnnotations;

namespace Labb2RestaurantMVC.Models.Booking
{
    public class BookingNew
    {
        public int Id { get; set; }
        public string CustomerFullName { get; set; }
        public int GuestAttending { get; set; }
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan BookingStart { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan BookingEnd { get; set; }
    }
}
