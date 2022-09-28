using System.ComponentModel.DataAnnotations;

namespace PeakBaggerAPI.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Area>? Areas { get; set; }
    }
}