using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class Pic
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Uri { get; set; }
        [Required]
        public long CheckId { get; set; }

        [ForeignKey("CheckId")]
        public virtual Check Check { get; set; }
    }
}
