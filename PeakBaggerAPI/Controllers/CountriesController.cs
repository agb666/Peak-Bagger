using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeakBaggerAPI.Data;
using PeakBaggerAPI.Dtos;
using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ILogger<CountriesController> _logger;
    private readonly ICountryRepo _repository;
        private readonly IMapper _mapper;

    public CountriesController(ILogger<CountriesController> logger, ICountryRepo repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
         _mapper = mapper;
    }

    [HttpGet]
    public  ActionResult<IEnumerable<CountryReadDto>> GetCountries()
    {
      var countryItems = _repository.GetCountries();
          return Ok(_mapper.Map<IEnumerable<CountryReadDto>>(countryItems));
    }

    [HttpGet("{id}", Name="GetCountryById")]
    public ActionResult<CountryReadDto> GetCountryById(int id)
    {
      var countryItem = _repository.GetCountryById(id);

      if(countryItem != null)
      { 
             // return Ok(countryItem);

             return Ok(_mapper.Map<CountryReadDto>(countryItem));
      }
      return NotFound();

    }
    
    [HttpPost]
    public ActionResult<CountryReadDto> CreateCountry(CountryCreateDto countryCreateDto)
    {
        var countryModel = _mapper.Map<Country>(countryCreateDto);
        _repository.CreateCountry(countryModel);
        _repository.SaveChanges();

        var countryReadDto = _mapper.Map<CountryReadDto>(countryModel);
        
        return CreatedAtRoute(nameof(GetCountryById), new {Id = countryReadDto.Id}, countryReadDto);
    }

    [HttpPut("{id}")]
     public ActionResult UpdateCountry(int id, CountryUpdateDto countryUpdateDto)
    {
        var countryModelFromRepo = _repository.GetCountryById(id);
        if(countryModelFromRepo == null)
        {
            return NotFound();
        }
        _mapper.Map(countryUpdateDto, countryModelFromRepo);
        _repository.UpdateCountry(countryModelFromRepo);
        _repository.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteeCountryById(int id)
    {
        var countryModelFromRepo = _repository.GetCountryById(id);
        if(countryModelFromRepo  == null)
        {
            return NotFound();
        }

        _repository.DeleteCountry(countryModelFromRepo);
        _repository.SaveChanges();

         return NoContent();
    }
}
