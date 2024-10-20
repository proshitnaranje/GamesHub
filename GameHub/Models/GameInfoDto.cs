using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class GameInfoDto(int id, string title, string genre, string description, int stockQuantity, double? price, DateTimeOffset? releaseDate)
    {
        public int ID { get; set; } = id;
        public string Title { get; set; } = title;
        public string Genre { get; set; } = genre;
        public string Description { get; set; } = description;
        public double? Price { get; set; } = price;
        public DateTimeOffset? ReleaseDate { get; set; } = releaseDate;
        public int StockQuantity { get; set; } = stockQuantity;
    }
}
