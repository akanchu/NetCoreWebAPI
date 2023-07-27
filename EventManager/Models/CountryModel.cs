using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
