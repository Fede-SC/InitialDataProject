using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class Diet
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime FirstDay { get; set; } // timestamp utc
        [Required]
        public long AuthorId { get; set; }
        public DateTime? LastDay { get; set; } // timestamp
        public string Description { get; set; } // text
        public string Name { get; set; }
        [Required]
        public int DiffFromNormo { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public bool Deleted { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<DietDay> DietDays { get; set; }
    }
}
