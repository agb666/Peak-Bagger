using System.ComponentModel.DataAnnotations;
using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Dtos
{
public class CountryCreateDto
{
	[Required]
	public string? Name  {get; set;}
}
}