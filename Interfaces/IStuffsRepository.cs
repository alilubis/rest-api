using RestAPI.Entities;

namespace RestAPI.Interfaces
{
    public interface IMemoryStuffsRepository
    {
        Stuff GetStuff(Guid id);
        IEnumerable<Stuff> GetStuffs();
        void CreateStuff(Stuff stuff);
        void UpdateStuff(Stuff stuff);
        void DeleteStuff(Guid id);
    }
}