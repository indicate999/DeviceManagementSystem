using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Data.Extensions;
using API.BusinessLogic.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAngularApp",
		builder => builder.WithOrigins("http://localhost:4200")
						  .AllowAnyMethod()
						  .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => {
	opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddServices();
builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();



// Apply the CORS policy
app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();


var databasePath = Path.Combine(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..")), "database");

if (!Directory.Exists(databasePath))
{
	Directory.CreateDirectory(databasePath);
}

using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<DataContext>();
	context.Database.Migrate();
}


app.Run();

