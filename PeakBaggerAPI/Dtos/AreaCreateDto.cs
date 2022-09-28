
using System.ComponentModel.DataAnnotations;

namespace PeakBaggerAPI.Dtos
{
    public class AreaCreateDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int CountryID { get; set; }

        public CountryCreateDto? Country { get; set; }

    }
}