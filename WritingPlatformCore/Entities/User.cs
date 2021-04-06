
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WritingPlatformCore.Entities
{
    public class User
    {
        #region Body
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Login { get; set; }
        [Required]
        [StringLength(250)]
        public string Password { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; }
        public bool IsDelete { get; set; }
        #endregion

        #region Relations
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<WorkItem> WorkItems { get; set; }
        #endregion

        #region Ctor
        public User()
        {
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
            WorkItems = new HashSet<WorkItem>();
        }
        #endregion
    }
}
