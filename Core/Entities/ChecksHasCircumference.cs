using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class ChecksHasCircumference
    {
        [Key]
        public long CheckId { get; set; }
        [Key]
        public long CircumferenceId { get; set; }
        [Required]
        public float Measure { get; set; }

        [ForeignKey("CheckId")]
        public virtual Check Check { get; set; }
        [ForeignKey("CircumferenceId")]
        public virtual Circumference Circumference { get; set; }
    }
}
