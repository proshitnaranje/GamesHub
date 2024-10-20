using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameHub.Entities
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Genre { get; set; } = string.Empty;

        public string? Description { get; set; }

        public double? Price { get; set; }

        public DateTimeOffset? ReleaseDate { get; set; }

        public int StockQuantity { get; set; }
    }
}
