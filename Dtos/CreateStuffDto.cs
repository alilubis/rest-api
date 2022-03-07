using System.ComponentModel.DataAnnotations;

namespace RestAPI.Dtos
{
    public record CreateStuffDto
    {
        [Required]
        public string? Name { get; init; }
        [Required]
        [Range(1, 1000000)]
        public decimal Price { get; init; }
    }
}