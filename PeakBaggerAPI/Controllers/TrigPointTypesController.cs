using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeakBaggerAPI.Data;
using PeakBaggerAPI.Dtos;



namespace PeakBaggerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TrigPointTypesController : ControllerBase
{
    private readonly ILogger<TrigPointTypesController> _logger;
    private readonly ITrigPointTypeRepo _repository;
    private readonly IMapper _mapper;

    public  TrigPointTypesController(ILogger<TrigPointTypesController>logger, ITrigPointTypeRepo repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public  ActionResult<IEnumerable<TrigPointTypeReadDto>> GetTrigPointType()
    {
      var trigPointTypeReadDtoItems = _repository.GetTrigPointTypes();
      return Ok(_mapper.Map<IEnumerable<TrigPointTypeReadDto>>(trigPointTypeReadDtoItems));
     
    }

    [HttpGet("{id}", Name="GetTrigPointTypeById")]
    public ActionResult<TrigPointTypeReadDto> GetTrigPointTypeById(int id)
    {

      var trigPointTypeReadDtoItem = _repository.GetTrigPointTypeById(id);
      if(trigPointTypeReadDtoItem  != null)
      { 
        return Ok(_mapper.Map<TrigPointTypeReadDto>(trigPointTypeReadDtoItem));
      }
      return NotFound();
    }

     
}
