using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Techpork.Core.Entities
{
    public class Food
    {
        [Key]
        public long Id { get; set; }
        //[Required]
        //public string Name { get; set; } // unique
        public string NameEn { get; set; }
        public string NameIt { get; set; }
        [Required]
        public double Carb { get; set; }
        [Required]
        public double Pro { get; set; }
        [Required]
        public double Fats { get; set; }
        [Required]
        public int Kcals { get; set; }
        public long? AuthorId { get; set; }
        [Required]
        public long SourceId { get; set; }
        public double Sugar { get; set; }
        [Required]
        public double Fibers { get; set; }

        [Required]
        public bool Deleted { get; set; }
        public int ServingSize { get; set; }
        public string ServingUnit { get; set; }
        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
        [ForeignKey("SourceId")]
        public virtual FoodSource Source { get; set; }
        public virtual ICollection<Portion> Portions { get; set; }
        public virtual ICollection<FoodHasTag> FoodHasTags { get; set; }
        public virtual ICollection<FoodHasMicronutrient> FoodHasMicronutrients { get; set; }
    }
}
