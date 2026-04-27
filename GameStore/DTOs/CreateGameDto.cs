using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;
public record CreateGameDto(
    [Required][StringLength(50)]string Title,
    [Required][StringLength(50)]string Genre,
    [Range(1,100)]decimal Price
);