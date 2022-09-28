using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeakBaggerAPI.Data;
using PeakBaggerAPI.Dtos;
using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PeaksController : ControllerBase
{
    private readonly ILogger<PeaksController> _logger;
    private readonly IPeakRepo _repository;
    private readonly IMapper _mapper;

    public PeaksController(ILogger<PeaksController> logger, IPeakRepo repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
         _mapper = mapper;
    }

    [HttpGet]
    public  ActionResult<IEnumerable<PeakReadDto>> GetAllPeaks()
    {
      var peakItems = _repository.GetPeaks();
          return Ok(_mapper.Map<IEnumerable<PeakReadDto>>(peakItems));
    }

    [HttpGet("{id}", Name="GetPeakById")]
    public ActionResult<PeakReadDto> GetPeakById(int id)
    {
      var peakItem = _repository.GetPeakById(id);

       if(peakItem != null)
      { 
        return Ok(_mapper.Map<PeakReadDto>(peakItem));
        //return Ok(peakItem);
      }
      return NotFound();
    }

    [HttpPost]
    public ActionResult<PeakReadDto> CreatePeak(PeakCreateDto peakCreateDto)
    {
        var peakModel = _mapper.Map<Peak>(peakCreateDto);
        _repository.CreatePeak(peakModel);
        _repository.SaveChanges();

        var peakReadDto = _mapper.Map<PeakReadDto>(peakModel);
        
        return CreatedAtRoute(nameof(GetPeakById), new {Id = peakReadDto.Id}, peakReadDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdatePeak(int id, PeakUpdateDto peakUpdateDto)
    {
        var peakModelFromRepo = _repository.GetPeakById(id);
        if(peakModelFromRepo == null)
        {
            return NotFound();
        }
        _mapper.Map(peakUpdateDto, peakModelFromRepo);
        _repository.UpdatePeak(peakModelFromRepo);
        _repository.SaveChanges();

        return NoContent();
    }

     [HttpDelete("{id}")]
    public ActionResult DeletePeakById(int id)
    {
        var peakModelFromRepo = _repository.GetPeakById(id);
        if(peakModelFromRepo  == null)
        {
            return NotFound();
        }

        _repository.DeletePeak(peakModelFromRepo);
        _repository.SaveChanges();

         return NoContent();
    }
}