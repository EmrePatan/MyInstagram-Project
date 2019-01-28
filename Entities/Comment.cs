using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Comments")]
    public class Comment : BaseEntity
    {
        [Required,StringLength(300)]
        public string Text { get; set; }

        public virtual User User { get; set; }
        public virtual Story Story { get; set; }
        public virtual List<Likes> Likes { get; set; }
    }
}
