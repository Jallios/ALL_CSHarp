using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// определяем IMongoDatabase как синглтон
builder.Services.AddSingleton(new MongoClient("mongodb://localhost:27017").GetDatabase("HAKATON"));
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

app.MapGet("Cities", async (IMongoDatabase db) =>     // получаем IMongoDatabase - базу данных "test" через DI
{
    var collection = db.GetCollection<BsonDocument>("cities"); // получаем коллекцию cities

    var cities = await collection.Find("{}").ToListAsync();
    return cities.ToJson();  // отправляем клиенту все документы из коллекции
});
app.MapGet("Events", async (IMongoDatabase db) =>     
{
    var collection = db.GetCollection<BsonDocument>("events"); 
                                                               

    var events = await collection.Find("{}").ToListAsync();
    return events.ToJson();  
});
app.MapGet("Excursions", async (IMongoDatabase db) =>     
{
    var collection = db.GetCollection<BsonDocument>("excursions"); 
                                                               

    var excursions = await collection.Find("{}").ToListAsync();
    return excursions.ToJson();  
});
app.MapGet("Hotels", async (IMongoDatabase db) =>     
{
    var collection = db.GetCollection<BsonDocument>("hotels"); 
                                                                   

    var hotels = await collection.Find("{}").ToListAsync();
    return hotels.ToJson();  
});
app.MapGet("Places", async (IMongoDatabase db) =>     
{
    var collection = db.GetCollection<BsonDocument>("places"); 
                                                               

    var places = await collection.Find("{}").ToListAsync();
    return places.ToJson();  
});
app.MapGet("Regions", async (IMongoDatabase db) =>     
{
    var collection = db.GetCollection<BsonDocument>("regions"); 
                                                               

    var regions = await collection.Find("{}").ToListAsync();
    return regions.ToJson();  
});
app.MapGet("Restaurants", async (IMongoDatabase db) =>     
{
    var collection = db.GetCollection<BsonDocument>("restaurants"); 
                                                                

    var restaurants = await collection.Find("{}").ToListAsync();
    return restaurants.ToJson();  
});
app.MapGet("Routes", async (IMongoDatabase db) =>     
{
    var collection = db.GetCollection<BsonDocument>("routes"); 
                                                                    

    var routes = await collection.Find("{}").ToListAsync();
    return routes.ToJson();  
});
app.MapGet("Tours", async (IMongoDatabase db) =>     
{
    var collection = db.GetCollection<BsonDocument>("tours"); 
                                                               

    var tours = await collection.Find("{}").ToListAsync();
    return tours.ToJson();  
});
app.MapGet("Tracks", async (IMongoDatabase db) =>     
{
    var collection = db.GetCollection<BsonDocument>("tracks"); 
                                                              

    var tracks = await collection.Find("{}").ToListAsync();
    return tracks.ToJson();  
});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
