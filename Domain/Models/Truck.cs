using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Truck : BaseModel
    {
        /// <summary>
        /// Unique truck code
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Truck name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Truck status
        /// </summary>
        public TruckStatus TruckStatus { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
    }
}
