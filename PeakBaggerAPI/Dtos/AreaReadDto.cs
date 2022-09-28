namespace PeakBaggerAPI.Dtos
{
    public class AreaReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CountryReadDto? Country { get; set; }
        //public int CountryId { get; set; }
        //public ICollection<PeakReadDto>? Peaks { get; set; }
    }
}