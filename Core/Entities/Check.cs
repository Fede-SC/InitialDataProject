using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class Check
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime Date { get; set; } // utc timestamp
        [Range(0, 500)]
        public float? Weight { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public bool Deleted { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<ChecksHasCircumference> ChecksHasCircumferences { get; set; }
    }
}
