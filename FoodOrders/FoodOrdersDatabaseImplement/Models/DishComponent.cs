using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FoodOrdersDatabaseImplement.Models
{
    [DataContract]
    public class DishComponent
    {
        public int Id { get; set; }

        [Required]
        public int DishId { get; set; }

        [Required]
        public int ComponentId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Component Component { get; set; } = new();

        public virtual Dish Dish { get; set; } = new();
    }
}