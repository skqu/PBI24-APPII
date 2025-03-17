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


app.MapGet("/HelloWorld", () =>
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
    return "{'msg': 'Success', 'username': " + username[id] + ", 'password': " + password[id] + "}";
});

app.Run();


record User(string Uname, string pwd);