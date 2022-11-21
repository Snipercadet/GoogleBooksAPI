using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(q =>
    q.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "@Asiiko Interview Task",
        Version = "v1",
        Description = "Code assessment on google books API",
        Contact = new OpenApiContact
        {
            Name = "Yakubu Abraham",
            Email = "donibris@gmail.com"
        }
    }));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
