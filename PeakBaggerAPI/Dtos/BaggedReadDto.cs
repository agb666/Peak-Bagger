
using System.ComponentModel.DataAnnotations;

namespace PeakBaggerAPI.Dtos
{
    public class BaggedReadDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? Comments { get; set; }
        public string? Images { get; set; }
        public string? WalkRoute { get; set; }
        public string? Kit { get; set; }
        public string? Weather { get; set; }
        //public int PeakId { get; set; }
        public PeakReadDto? Peak { get; set; }

    }
}