
using EditorMTZ.weather;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var sumaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/", (HttpContext context) =>
{
    var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 35),
        Summary = sumaries[Random.Shared.Next(sumaries.Length)]
    }).ToArray();

    return forecast;
});
app.Run();