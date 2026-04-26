namespace GameStore.DTOs;
public record CreateGameDto(
    string Title,
    string Genre,
    decimal Price
);