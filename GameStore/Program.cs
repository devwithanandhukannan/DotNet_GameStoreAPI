using GameStore.Data;
using GameStore.DTOs;
using GameStore.Endpoints;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
var connString = "Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(connString);
var app = builder.Build();
app.MapGamesEndpoints();

app.MapGet("/genres", async (GameStoreContext db) => 
    await db.Genres.AsNoTracking().ToListAsync());

app.MapPost("/genres", async (Genre newGenre, GameStoreContext db) => {
    db.Genres.Add(newGenre);
    await db.SaveChangesAsync();
    return Results.Created($"/genres/{newGenre.Id}", newGenre);
});
app.Run();
