using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeakBaggerAPI.Data;
using PeakBaggerAPI.Dtos;
using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AreasController : ControllerBase
{
    private readonly ILogger<AreasController> _logger;
    private readonly IAreaRepo _repository;
    private readonly IMapper _mapper;

    public AreasController(ILogger<AreasController> logger, IAreaRepo repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public  ActionResult<IEnumerable<AreaReadDto>> GetAreas()
    {
      var areaItems = _repository.GetAreas();
       return Ok(_mapper.Map<IEnumerable<AreaReadDto>>(areaItems));
    }

    [HttpGet("{id}", Name="GetAreaById")]
    public ActionResult<AreaReadDto> GetAreaById(int id)
    {
      var areaItem = _repository.GetAreaById(id);

      if(areaItem != null)
      { 
        return Ok(_mapper.Map<AreaReadDto>(areaItem));
        //return Ok(areaItem);
      }
      return NotFound();
    }

     [HttpPost]
    public ActionResult<AreaReadDto> CreateCountry(AreaCreateDto areaCreateDto)
    {
        var areaModel = _mapper.Map<Area>(areaCreateDto);
        _repository.CreateArea(areaModel);
        _repository.SaveChanges();

        var areaReadDto = _mapper.Map<AreaReadDto>(areaModel);
        
        return CreatedAtRoute(nameof(GetAreaById), new {Id = areaReadDto.Id}, areaReadDto);

    }

    [HttpPut("{id}")]
     public ActionResult UpdateArea(int id, AreaUpdateDto areaUpdateDto)
    {
        var areaModelFromRepo = _repository.GetAreaById(id);
        if(areaModelFromRepo == null)
        {
            return NotFound();
        }
        _mapper.Map(areaUpdateDto, areaModelFromRepo);
        _repository.UpdateArea(areaModelFromRepo);
        _repository.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAreaById(int id)
    {
        var areaModelFromRepo = _repository.GetAreaById(id);
        if(areaModelFromRepo  == null)
        {
            return NotFound();
        }

        _repository.DeleteArea(areaModelFromRepo);
        _repository.SaveChanges();

         return NoContent();
    }

}
