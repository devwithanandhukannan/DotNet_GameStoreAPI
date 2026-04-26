namespace GameStore.DTOs;

public record UpdateGameDto(
    string Title,
    string Genre,
    decimal Price
);