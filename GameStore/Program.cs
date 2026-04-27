using GameStore.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> Games = new()
{
    new GameDto(Guid.NewGuid(),"A","sports",2000.9m),
    new GameDto(Guid.NewGuid(), "FIFA 24", "Sports", 2999.99m),
    new GameDto(Guid.NewGuid(), "GTA V", "Action", 1999.50m),
    new GameDto(Guid.NewGuid(), "Minecraft", "Sandbox", 1499.00m)    
};

app.MapGet("/", () => Games);
app.MapGet("/{name}",(string name) =>{ 
    var game = Games.Find(game=>game.Title == name);
    return game is null ? Results.NoContent() : Results.Ok(game);
    }).WithName("getName");
app.MapPost("/",(CreateGameDto createGame) =>
{
    var game = new GameDto(
        Guid.NewGuid(),
        createGame.Title,
        createGame.Genre,
        createGame.Price
    );

    Games.Add(game);
    return Results.CreatedAtRoute("getName", new { name = game.Title },game);
});
app.MapPut("/{id}",(Guid id, UpdateGameDto updatedValues) =>
{
    var gameIndex = Games.FindIndex( game => game.Id == id);
    if(gameIndex == -1){
        return Results.NoContent();
    }
    Games[gameIndex] = new GameDto(
        id,
        updatedValues.Title,
        updatedValues.Genre,
        updatedValues.Price
    );

    return Results.NoContent();    
});
app.MapDelete("/{id}", (Guid id) =>
{
    Games.RemoveAll(games => games.Id == id);
    return Results.NoContent();
});

app.Run();
