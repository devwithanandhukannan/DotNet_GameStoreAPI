namespace GameStore.DTOs;
public record GameDto(
    Guid Id,
    string Title,
    string Genre,
    decimal Price
);