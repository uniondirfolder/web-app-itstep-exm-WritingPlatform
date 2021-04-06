using System.ComponentModel.DataAnnotations;

namespace WritingPlatformCore.Entities
{
    public class Rating
    {
        #region Body
        [Key]
        public int Id { get; set; }
        public int? Rank { get; set; }
        #endregion

        #region Relations
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? WorkId { get; set; }
        public virtual WorkItem WorkItem { get; set; }
        #endregion

    }
}