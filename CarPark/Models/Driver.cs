using System.ComponentModel.DataAnnotations;

namespace CarPark.Models
{
    public class Driver : BaseModel
    {
        [Required]
        public required string Name { get; set; }
    }
}
