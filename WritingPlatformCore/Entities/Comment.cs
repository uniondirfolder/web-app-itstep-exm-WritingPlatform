using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WritingPlatformCore.Entities
{
    public class Comment
    {
        #region Body
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Context { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateTimeOfCreate { get; set; }
        #endregion

        #region Relations
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? WorkItemId { get; set; }
        public virtual WorkItem WorkItem { get; set; }
        #endregion
    }
}