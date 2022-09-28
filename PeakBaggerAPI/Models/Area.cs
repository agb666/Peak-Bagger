
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeakBaggerAPI.Models
{
    public class Area
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public Country? Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<Peak>? Peaks { get; set; }
    }
}