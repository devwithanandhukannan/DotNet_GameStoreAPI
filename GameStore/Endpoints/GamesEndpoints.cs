using GameStore.Data;
using GameStore.Models;
using GameStore.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Endpoints;

public static class GamesEndpoints {
    public static void MapGamesEndpoints(this WebApplication app) {
        var group = app.MapGroup("/games");

        // 1. GET ALL GAMES
        group.MapGet("/", async (GameStoreContext db) => 
            await db.Games
                    .Include(g => g.Genre) 
                    .Select(g => new GameDto(g.Id, g.Name, g.Genre!.Name, g.Price))
                    .ToListAsync());

        // 2. GET BY ID
        group.MapGet("/{id}", async (int id, GameStoreContext db) =>
            await db.Games.FindAsync(id) is Game g 
                ? Results.Ok(new GameDto(g.Id, g.Name, g.Genre!.Name, g.Price)) 
                : Results.NotFound());

        // 3. POST (CREATE)
        group.MapPost("/", async (CreateGameDto dto, GameStoreContext db) => {
            var game = new Game {
                Name = dto.Name,
                GenreId = dto.GenreId,
                Price = dto.Price
            };
            db.Games.Add(game);
            await db.SaveChangesAsync(); 
            return Results.Created($"/games/{game.Id}", game);
        });

        // 4. PUT (UPDATE)
        group.MapPut("/{id}", async (int id, UpdateGameDto dto, GameStoreContext db) => {
            var existingGame = await db.Games.FindAsync(id);
            if (existingGame is null) return Results.NotFound();

            existingGame.Name = dto.Name;
            existingGame.GenreId = dto.GenreId;
            existingGame.Price = dto.Price;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        // 5. DELETE
        group.MapDelete("/{id}", async (int id, GameStoreContext db) => {
            var game = await db.Games.FindAsync(id);
            if (game is null) return Results.NotFound();

            db.Games.Remove(game);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        
    }
}