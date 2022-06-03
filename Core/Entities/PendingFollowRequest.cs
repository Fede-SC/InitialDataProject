using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class PendingFollowRequest
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long CoachId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public DateTime Date { get; set; } // timestamp
        //public Topic? Topic { get; set; }

        [ForeignKey("CoachId")]
        public virtual User Coach { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
