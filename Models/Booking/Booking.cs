using System.ComponentModel.DataAnnotations;

namespace Labb2RestaurantMVC.Models.Booking
{
    public class Booking
    {

        public int Id { get; set; }

        public int TableId { get; set; }

        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CustomersPhoneNo { get; set; }

        public string Email { get; set; }

        public int GuestAttending { get; set; }

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
