using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public enum Gender
    {
        Male,
        Female
    }
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Email { get; set; } // Unique
        [StringLength(15, MinimumLength = 3)]
        public string Username { get; set; } // Unique
        public string Password { get; set; }
        public long? TrainerId { get; set; } // Foreign Key
        public long? NutritionistId { get; set; } // Foreign Key
        public DateTime? Birthday { get; set; } // Date
        public Gender? Gender { get; set; }
        public int Avatar { get; set; }
        [Range(0, 300)]
        public int? Height { get; set; }
        [Required]
        public bool Visible { get; set; } // default true

        [ForeignKey("TrainerId")]
        public virtual User Trainer { get; set; }
        [ForeignKey("NutritionistId")]
        public virtual User Nutritionist { get; set; }
        public virtual ICollection<Attachment> AuthorAttachments { get; set; }
        public virtual ICollection<Attachment> UserAttachments { get; set; }
        public virtual ICollection<Diet> AuthorDiets { get; set; }
        public virtual ICollection<Diet> UserDiets { get; set; }
        public virtual ICollection<Check> Checks { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<User> TrainerUsers { get; set; }
        public virtual ICollection<User> NutritionistUsers { get; set; }
        public virtual ICollection<PendingFollowRequest> CoachPendingFollowRequests { get; set; }
        public virtual ICollection<PendingFollowRequest> UserPendingFollowRequests { get; set; }
    }
}
