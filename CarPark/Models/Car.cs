using System.ComponentModel.DataAnnotations;

namespace CarPark.Models
{
    public class Car : BaseModel
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Make { get; set; }
    }
}
