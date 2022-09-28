
using System.ComponentModel.DataAnnotations;

namespace PeakBaggerAPI.Dtos
{
    public class AreaUpdateDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int CountryID { get; set; }
    }
}