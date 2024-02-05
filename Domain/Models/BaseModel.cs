using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class BaseModel
    {
        /// <summary>
        /// Unique identification key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Modification date
        /// </summary>
        public DateTime ModificationDate { get; set; }
    }
}
