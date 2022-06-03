using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class FoodHasTag
    {
        [Key]
        public long FoodId { get; set; }
        [Key]
        public long FoodTagId { get; set; }
        
        [ForeignKey("FoodId")]
        public virtual Food Food { get; set; }
        [ForeignKey("FoodTagId")]
        public virtual FoodTag FoodTag { get; set; }
    }
}
