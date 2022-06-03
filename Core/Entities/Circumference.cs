using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Techpork.Core.Entities
{
    public class Circumference
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int Code { get; set; } // unique
        public string HelpPicUri { get; set; }

        public virtual ICollection<ChecksHasCircumference> ChecksHasCircumferences { get; set; }
    }
}
