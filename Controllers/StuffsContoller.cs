using Microsoft.AspNetCore.Mvc;
using RestAPI.Dtos;
using RestAPI.Entities;
using RestAPI.Interfaces;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("stuff")] // GET / stuff
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
    }
}