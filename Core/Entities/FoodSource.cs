using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Techpork.Core.Entities
{
    public class FoodSource
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
