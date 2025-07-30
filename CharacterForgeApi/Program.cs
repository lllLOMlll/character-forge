var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();    // nécessaire pour la doc minimal API
builder.Services.AddSwaggerGen();              // génère la spec OpenAPI

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", builder =>
	{
		builder.AllowAnyOrigin()    // tout le monde peut appeler
			   .AllowAnyMethod()    // GET, POST, etc.
			   .AllowAnyHeader();   // tous les en-têtes HTTP autorisés
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
