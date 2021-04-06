using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WritingPlatformCore.Entities
{
    public class WorkItem
    {
        #region Body
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfPublication { get; set; }

        [Required]
        public string Content { get; set; }

        #endregion

        #region Relations
        public int UserId { get; set; }
        public virtual User Users { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genres { get; set; }
       
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        #endregion

        #region Ctor
        public WorkItem()
        {
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
        }
        #endregion
    }
}