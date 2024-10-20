using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class GameCreationDto
    {
        [Required(ErrorMessage = "You should provide a Title.")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "You should provide a Genre.")]
        [MaxLength(100)]
        public string Genre { get; set; } = string.Empty;

        public string? Description { get; set; }

        public double? Price { get; set; }

        public DateTimeOffset? ReleaseDate { get; set; }

        public int StockQuantity { get; set; } = 0;
    }
}
