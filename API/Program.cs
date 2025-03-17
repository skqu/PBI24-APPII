var builder = WebApplication.CreateBuilder(args);

List<string> username = new List<string>();
List<string> password = new List<string>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy =>
        {
            policy.WithOrigins("http://localhost", "https://localhost") // Adjust the port if necessary
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();

// Use CORS
app.UseCors("AllowLocalhost");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return "Hello World";
})
.WithName("GetWeatherForecast");



app.MapPut("/user", (User user) => 
{
    Console.WriteLine("Hello");
    username.Add(user.Uname);
    password.Add(user.pwd);
    Console.WriteLine("{'msg': 'success', 'id': "+ username.Count() +"}");
    return "{'msg': 'success', 'id': "+ username.Count() +"}";
});

app.MapGet("/user/{id}", (int id) => 
{
    return "{'msg': 'Success', 'username': " + username[id] + ", 'password': " + password[id] + "}";
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

record User(string Uname, string pwd);