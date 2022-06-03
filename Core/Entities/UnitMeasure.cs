using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Techpork.Core.Entities
{
    public class UnitMeasure
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } // unique

        public virtual ICollection<FoodHasMicronutrient> FoodHasMicronutrients { get; set; }
    }
}
