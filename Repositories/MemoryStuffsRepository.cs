using RestAPI.Entities;
using RestAPI.Interfaces;

namespace RestAPI.Repositories
{    
    public class MemoryStuffsRepository : IMemoryStuffsRepository
    {
        private readonly List<Stuff> stuffs = new()
        {
            new Stuff { Id = Guid.NewGuid(), Name = "Monitor", Price = 900, CreatedDate = DateTimeOffset.UtcNow },
            new Stuff { Id = Guid.NewGuid(), Name = "Keyboard", Price = 100, CreatedDate = DateTimeOffset.UtcNow },
            new Stuff { Id = Guid.NewGuid(), Name = "Mouse", Price = 10, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Stuff> GetStuffs()
        {
            return stuffs;
        }

        public Stuff GetStuff(Guid id)
        {
            return stuffs.Where(stuff => stuff.Id == id).SingleOrDefault();
        }
    }
}