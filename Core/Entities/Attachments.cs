using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public enum Topic
    {
        Nutrition,
        Training
    }
    public class Attachment
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long AuthorId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime LastChange { get; set; } // timestamp
        [Required]
        public string Uri { get; set; }
        //public Topic Topic { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
