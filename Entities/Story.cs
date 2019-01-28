using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Stories")]
    public class Story : BaseEntity
    {
        public int LikeCount { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public string Text { get; set; }

        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Likes> Likes { get; set; }
        public virtual Locations Location { get; set; }
    }
}
