using Microsoft.AspNetCore.Mvc;
using RestAPI.Entities;
using RestAPI.Repositories;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("stuff")] // GET / stuff
    public class StuffsContoller : ControllerBase
    {
        private readonly MemoryStuffsRepository repository;

        public StuffsContoller()
        {
            repository = new MemoryStuffsRepository();
        }

        [HttpGet] // Get / stuff
        public IEnumerable<Stuff> GetStuffs()
        {
            var stuffs = repository.GetStuffs();
            return stuffs;
        }

        [HttpGet("{id}")] // Get / stuff {id}
        public ActionResult<Stuff> GetStuff(Guid id)
        {
            var stuff = repository.GetStuff(id);

            if(stuff is null)
            {
                return NotFound();
            }

            return Ok(stuff);
        }
    }
}