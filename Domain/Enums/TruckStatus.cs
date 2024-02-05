using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum TruckStatus
    {
        /// <summary>
        /// Out Of Service
        /// </summary>
        [Display(Name = "Out Of Service")]
        OutOfService = 0,
        /// <summary>
        /// Loading
        /// </summary>
        [Display(Name = "Loading")]
        Loading = 1,
        /// <summary>
        /// To job
        /// </summary>
        [Display(Name = "To job")]
        ToJob = 2,
        /// <summary>
        /// At job
        /// </summary>
        [Display(Name = "At job")]
        AtJob = 3,
        /// <summary>
        /// Returning
        /// </summary>
        [Display(Name = "Returning")]
        Returning = 4
    }
}
