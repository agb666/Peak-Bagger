using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PeakBaggerAPI.Data;
using PeakBaggerAPI.Dtos;
using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BaggedController : ControllerBase
{
    private readonly ILogger<BaggedController> _logger;
    private readonly IBaggedRepo _repository;
    private readonly IMapper _mapper;

    public BaggedController(ILogger<BaggedController> logger, IBaggedRepo repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BaggedReadDto>> GetBagged()
    {
        var baggedItems = _repository.GetBagged();
        return Ok(_mapper.Map<IEnumerable<BaggedReadDto>>(baggedItems));
    }

    [HttpGet("{id}", Name = "GetBaggedById")]
    public ActionResult<BaggedReadDto> GetBaggedById(int id)
    {
        var baggedItem = _repository.GetBaggedById(id);

        if (baggedItem != null)
        {
            return Ok(_mapper.Map<BaggedReadDto>(baggedItem));
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<BaggedReadDto> CreateBagged(BaggedCreateDto baggedCreateDto)
    {
        var baggedModel = _mapper.Map<Bagged>(baggedCreateDto);
        _repository.CreateBagged(baggedModel);
        _repository.SaveChanges();

        var baggedReadDto = _mapper.Map<BaggedReadDto>(baggedModel);

        return CreatedAtRoute(nameof(GetBaggedById), new { Id = baggedReadDto.Id }, baggedReadDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdatePeak(int id, BaggedReadDto baggedUpdateDto)
    {
        var baggedModelFromRepo = _repository.GetBaggedById(id);
        if(baggedModelFromRepo == null)
        {
            return NotFound();
        }
        _mapper.Map(baggedUpdateDto, baggedModelFromRepo);
        _repository.UpdateBagged(baggedModelFromRepo);
        _repository.SaveChanges();

        return NoContent();
    }

 [HttpPatch("{id}")]
     public ActionResult UpdatePartialBagged(int id, JsonPatchDocument<BaggedUpdateDto> patchDoc)
     {
        var baggedModelFromRepo = _repository.GetBaggedById(id);
        if(baggedModelFromRepo == null)
        {
            return NotFound();
        }
     
        var baggedToPatch = _mapper.Map<BaggedUpdateDto>(baggedModelFromRepo);
        patchDoc.ApplyTo(baggedToPatch, ModelState);
        if(!TryValidateModel(baggedToPatch))
        {
           return ValidationProblem(ModelState);
        }

        _mapper.Map(baggedToPatch, baggedModelFromRepo);
        _repository.UpdateBagged(baggedModelFromRepo);
        _repository.SaveChanges();

        return NoContent();
     }


    [HttpDelete("{id}")]
    public ActionResult DeleteBaggedById(int id)
    {
        var baggedModelFromRepo = _repository.GetBaggedById(id);
        if (baggedModelFromRepo == null)
        {
            return NotFound();
        }

        _repository.DeleteBagged(baggedModelFromRepo);
        _repository.SaveChanges();

        return NoContent();
    }
}

