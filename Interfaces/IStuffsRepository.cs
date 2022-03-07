using RestAPI.Entities;

namespace RestAPI.Interfaces
{
    public interface IMemoryStuffsRepository
    {
        Stuff GetStuff(Guid id);
        IEnumerable<Stuff> GetStuffs();
    }
}