using RestAPI.Dtos;
using RestAPI.Entities;

namespace RestAPI
{
    public static class Extentions 
    {
        public static StuffDto AsDto(this Stuff stuff)
        {
            return new StuffDto {
                    Id = stuff.Id,
                    Name = stuff.Name,
                    Price = stuff.Price,
                    CreatedDate = stuff.CreatedDate
                };
        }
    }
}