using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeakBaggerAPI.Data;
using PeakBaggerAPI.Dtos;
using PeakBaggerAPI.Models;
using Microsoft.AspNetCore.JsonPatch;


namespace PeakBaggerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TagsController : ControllerBase
{
    private readonly ILogger<TagsController> _logger;
    private readonly ITagRepo _repository;
    private readonly IMapper _mapper;

    public TagsController(ILogger<TagsController> logger, ITagRepo repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public  ActionResult<IEnumerable<TagReadDto>> GetTags()
    {
      var tagItems = _repository.GetTags();
      return Ok(_mapper.Map<IEnumerable<TagReadDto>>(tagItems));
     
    }

    [HttpGet("{id}", Name="GetTagById")]
    public ActionResult<TagReadDto> GetTagById(int id)
    {

      var tagItem = _repository.GetTagById(id);
      if(tagItem != null)
      { 
        return Ok(_mapper.Map<TagReadDto>(tagItem));
      }
      return NotFound();
    }

      [HttpPost]
    public ActionResult<TagReadDto> CreateTag(TagCreateDto tagCreateDto)
    {
        var tagModel = _mapper.Map<Tag>(tagCreateDto);
        _repository.CreateTag(tagModel);
        _repository.SaveChanges();

        var tagReadDto = _mapper.Map<TagReadDto>(tagModel);
        
        return CreatedAtRoute(nameof(GetTagById), new {Id = tagReadDto.Id}, tagReadDto);
    }

     [HttpPut("{id}")]
     public ActionResult UpdateTag(int id, TagUpdateDto tagUpdateDto)
    {
        var tagModelFromRepo = _repository.GetTagById(id);
        if(tagModelFromRepo == null)
        {
            return NotFound();
        }
        _mapper.Map(tagUpdateDto, tagModelFromRepo);
        _repository.UpdateTag(tagModelFromRepo);
        _repository.SaveChanges();

        return NoContent();
    }

     [HttpPatch("{id}")]
     public ActionResult UpdatePartialTag(int id, JsonPatchDocument<TagUpdateDto> patchDoc)
     {
        var tagModelFromRepo = _repository.GetTagById(id);
        if(tagModelFromRepo == null)
        {
            return NotFound();
        }
        var tagToPatch = _mapper.Map<TagUpdateDto>(tagModelFromRepo);
        patchDoc.ApplyTo(tagToPatch, ModelState);
        if(!TryValidateModel(tagToPatch))
        {
           return ValidationProblem(ModelState);
        }

        _mapper.Map(tagToPatch, tagModelFromRepo);
        _repository.UpdateTag(tagModelFromRepo);
        _repository.SaveChanges();

        return NoContent();
     }

    [HttpDelete("{id}")]
    public ActionResult DeleteTagById(int id)
    {
        var tagModelFromRepo = _repository.GetTagById(id);
        if(tagModelFromRepo == null)
        {
            return NotFound();
        }

        _repository.DeleteTag(tagModelFromRepo);
        _repository.SaveChanges();

         return NoContent();
    }
}
