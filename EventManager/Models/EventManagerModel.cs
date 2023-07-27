using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class EventManagerModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
