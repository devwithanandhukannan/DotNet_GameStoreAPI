namespace GameStore.DTOs;

public record UpdateGameDto(string Name, int GenreId, decimal Price);