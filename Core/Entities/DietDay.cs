using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class DietDay
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int DietIndex { get; set; }
        [Required]
        public long DietId { get; set; }

        [ForeignKey("DietId")]
        public virtual Diet Diet { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
