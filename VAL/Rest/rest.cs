using System.Data.SqlTypes;
using Microsoft.AspNetCore.Authentication.Cookies;

class Rest
{
    
    private WebApplicationBuilder builder;
    private WebApplication app;
    private User usr; 

    public Rest(string[] args)
    {
        builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        this.builder.Services.AddOpenApi();
    }

    public Rest(string[] args, User usr)
    {
                builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        this.builder.Services.AddOpenApi();
        this.usr = usr; 
    }

    public bool OpenApi()
    {

        
        // Configure the HTTP request pipeline.
        if (this.app.Environment.IsDevelopment())
        {
            this.app.MapOpenApi();
        }

        return true;
    }

    public bool Build()
    {
        this.app = this.builder.Build();
        return true;
    }

    public bool https(bool use)
    {
        if (use)
        {
            this.app.UseHttpsRedirection();
        }

        return use;
    }

    public bool get()
    {
        
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        this.app.MapGet("/weatherforecast", () =>
        {
            var forecast =  Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast");
        return true;
    }

    public bool post()
    {
        this.app.MapPost("/user/login", () => {
            usr.authorizeUser("skqu", "secret");
            Console.WriteLine("Hello There");
        });

        return true;
    }

    public void run()
    {
        this.app.Run();
    }
}






record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
