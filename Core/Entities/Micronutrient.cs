using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class Micronutrient
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } // unique
        public long? FatherId { get; set; }

        [ForeignKey("FatherId")]
        public virtual Micronutrient Father { get; set; }

        public virtual ICollection<FoodHasMicronutrient> FoodHasMicronutrients { get; set; }
        public virtual ICollection<Micronutrient> Children { get; set; }
    }
}
