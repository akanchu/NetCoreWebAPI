using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class KOLModel
    {
        public int KOLId { get; set; }
        [Required]
        public int CountryId { get; set; }
        public int? CreatedBy { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ProfileImage { get; set; }
        [Required]
        public Boolean IsDeleted { get; set; }
    }
}
