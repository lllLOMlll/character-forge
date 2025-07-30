using CharacterForgeApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddDbContext<CharacterDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();    // n�cessaire pour la doc minimal API
builder.Services.AddSwaggerGen();              // g�n�re la spec OpenAPI

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", builder =>
	{
		builder.AllowAnyOrigin()    // tout le monde peut appeler
			   .AllowAnyMethod()    // GET, POST, etc.
			   .AllowAnyHeader();   // tous les en-t�tes HTTP autoris�s
	});
});


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(); // URL: https://localhost:xxxx/swagger
}


app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
