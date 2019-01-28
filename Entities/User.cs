using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required, StringLength(30)]
        public string Name { get; set; }
        [Required, StringLength(30)]
        public string Surname { get; set; }
        [Required, StringLength(30)]
        public string Username { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(30)]
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsOnline { get; set; }
        public int? FollowersCount { get; set; }
        public int? FollowingCount { get; set; }

        public virtual List<Story> Stories { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Likes> Likes { get; set; }
    }
}
