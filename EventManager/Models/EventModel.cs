using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class EventModel
    {
        public int EventId { get; set; }
        public int? EventTypeId { get; set; }
        [Required]
        public string EventTitle { get; set; }
        public int? CountryId { get; set; }
        public int? CreatedBy { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int BusinessOwnerId { get; set; }
        [Required]
        public Boolean IsDeleted { get; set; }
        [Required]
        public string EventIcon { get; set; }
    }
}
