using Microsoft.AspNetCore.Mvc;
using RestAPI.Dtos;
using RestAPI.Entities;
using RestAPI.Interfaces;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("stuff")] 
    public class StuffsContoller : ControllerBase
    {
        private readonly IMemoryStuffsRepository repository;

        public StuffsContoller(IMemoryStuffsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet] // Get / stuff
        public IEnumerable<StuffDto> GetStuffs()
        {
            var stuffs = repository.GetStuffs()
                .Select(stuff => stuff.AsDto());
            return stuffs;
        }

        [HttpGet("{id}")] // Get / stuff {id}
        public ActionResult<StuffDto> GetStuff(Guid id)
        {
            var stuff = repository.GetStuff(id);

            if(stuff is null)
            {
                return NotFound();
            }

            return stuff.AsDto();
        }

        [HttpPost] // Post // stuff
        public ActionResult<StuffDto> CreateStuff (CreateStuffDto stuffDto)
        {
            Stuff stuff = new(){
                Id = Guid.NewGuid(),
                Name = stuffDto.Name,
                Price = stuffDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateStuff(stuff);

            return CreatedAtAction(nameof(GetStuff), new { id = stuff.Id}, stuff.AsDto());
        }

        [HttpPut("{id}")] // Put / stuff / {id}
        public ActionResult UpdateStuff(Guid id, UpdateStuffDto stuffDto)
        {
            var ei = repository.GetStuff(id);
            if(ei is null)
            {
                return NotFound();
            }

            Stuff updateStuff = ei with
                {
                    Name = stuffDto.Name,
                    Price = stuffDto.Price
                };
            
            repository.UpdateStuff(updateStuff);

            return NoContent();
        }

        [HttpDelete("{id}")] // Delete / stuff / {id}
        public ActionResult DeleteStuff(Guid id)
        {
            var ei = repository.GetStuff(id);
            if(ei is null)
            {
                return NotFound();
            }

            repository.DeleteStuff(id);

            return NoContent();
        }
    }
}