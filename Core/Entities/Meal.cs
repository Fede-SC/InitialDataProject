using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class Meal
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int DayIndex { get; set; }
        [Required]
        public long DietDayId { get; set; }

        [ForeignKey("DietDayId")]
        public virtual DietDay DietDay { get; set; }

        public virtual ICollection<Portion> Portions { get; set; }
    }
}
