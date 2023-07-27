using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class EventTypeModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
