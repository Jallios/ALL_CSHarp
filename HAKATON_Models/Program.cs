using HAKATON_Models;
using HAKATON_Models.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<HAKATONDatabaseSettings>(
    builder.Configuration.GetSection("HAKATONDatabase"));


builder.Services.AddSingleton<ToursService>();
builder.Services.AddSingleton<RoutesService>();
builder.Services.AddSingleton<TracksService>();
builder.Services.AddSingleton<RestaurantsService>();
builder.Services.AddSingleton<HotelsService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
