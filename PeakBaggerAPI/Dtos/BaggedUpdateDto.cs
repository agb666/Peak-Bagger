
using System.ComponentModel.DataAnnotations;

namespace PeakBaggerAPI.Dtos
{
    public class BaggedUpdateDto
    {
        [Required]
        public DateTime Date { get; set; }
        public string? Comments { get; set; }
        public string? Images { get; set; }
        public string? WalkRoute { get; set; }
        public string? Kit { get; set; }
        public string? Weather { get; set; }
        [Required]
        public int PeakId { get; set; }
        // public PeakUpdateDto? Peak { get; set; }
    }
}