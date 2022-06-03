using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class FoodHasMicronutrient
    {
        [Key]
        public long FoodId { get; set; }
        [Key]
        public long MicronutrientId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public long UnitMeasureId { get; set; }

        [ForeignKey("FoodId")]
        public virtual Food Food { get; set; }
        [ForeignKey("MicronutrientId")]
        public virtual Micronutrient Micronutrient { get; set; }
        [ForeignKey("UnitMeasureId")]
        public virtual UnitMeasure UnitMeasure { get; set; }
    }
}
