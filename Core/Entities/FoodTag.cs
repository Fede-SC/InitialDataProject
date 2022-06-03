using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Techpork.Core.Entities
{
    public class FoodTag
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int Code { get; set; } // unique

        public virtual ICollection<FoodHasTag> FoodHasTags { get; set; }
    }
}
