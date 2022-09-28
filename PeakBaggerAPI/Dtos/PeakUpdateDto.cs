using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeakBaggerAPI.Dtos
{
    public class PeakUpdateDto
    {
        [Required]
        public string? Name { get; set; }
        public string? Height { get; set; }
        [Required]
        public string? LoactionRefernce { get; set; }
        public string? Description { get; set; }
        [Required]
        public int AreaId { get; set; }
        public int Tag { get; set; }
    }
}