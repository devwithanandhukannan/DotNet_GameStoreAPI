namespace GameStore.Models;

public class Game
{
    public int Id {get; set;}
    public required string Name { get; set; }
    public int GenreId { get; set; } // Foreign Key
    public Genre? Genre { get; set; } // Navigation Property
    public decimal Price { get; set; }
}
