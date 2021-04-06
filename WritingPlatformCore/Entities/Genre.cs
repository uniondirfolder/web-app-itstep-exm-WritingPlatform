using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WritingPlatformCore.Entities
{
    public class Genre
    {
        #region Body
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        #endregion

        #region Relations
        public virtual ICollection<WorkItem> WorkItems { get; set; }
        #endregion

        #region Ctor
        public Genre()
        {
            WorkItems = new HashSet<WorkItem>();
        }
        #endregion
    }
}