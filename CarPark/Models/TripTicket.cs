using System.ComponentModel.DataAnnotations;

namespace CarPark.Models
{
    public class TripTicket : BaseModel
    {
        [Required(ErrorMessage = "Enter number")]
        public required string Number { get; set; }
        public Car? Car { get; set; }
        public Driver? Driver { get; set; }
        public bool IsMarked { get; set; }
        public bool IsClosed { get; set; }
    }
}
