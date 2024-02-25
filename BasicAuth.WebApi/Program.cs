using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy(name: "WeatherOrigins",
    policy =>
    {
        policy.WithOrigins("https://bigmoneybois.hu/").AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

app.UseCors("WeatherOrigins");

app.Use(async (context, next) =>
{
    app.Logger.LogInformation(JsonSerializer.Serialize(context.Request.Headers));
    Console.WriteLine(JsonSerializer.Serialize(context.Request.Headers));
    await next.Invoke();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
