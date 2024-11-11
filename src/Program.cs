using LilyFNServer.Utils;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! Hot Realod pt2!");

app.Run();
