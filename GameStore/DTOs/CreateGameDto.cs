using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;
public record CreateGameDto(string Name, int GenreId, decimal Price);