var builder = WebApplication.CreateBuilder(args);

List<string> username = new List<string>();
List<string> password = new List<string>();


username.Add("skqu@iba.dk");
password.Add("Secret");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();

// Use CORS
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.MapGet("/weatherforecast", () =>
{
    return "{'msg':'Hello World'}";
})
.WithName("GetHelloWorld");



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
    var userData = new 
    { 
        msg = "Success", 
        username = username[id], 
        password = password[id] 
    };

    return Results.Json(userData); // Ensure JSON response
});

app.Run();


record User(string Uname, string pwd);