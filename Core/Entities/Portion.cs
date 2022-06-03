using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class Portion
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public long MealId { get; set; }
        [Required]
        public long FoodId { get; set; }
        [ForeignKey("MealId")]
        public virtual Meal Meal { get; set; }
        [ForeignKey("FoodId")]
        public virtual Food Food { get; set; }
    }
}
