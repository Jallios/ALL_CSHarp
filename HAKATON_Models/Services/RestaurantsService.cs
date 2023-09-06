using HAKATON_Models.Models.Restaurants;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HAKATON_Models.Services
{
    public class RestaurantsService
    {
        private readonly IMongoCollection<Restaurants> _Collection;

        public RestaurantsService(
            IOptions<HAKATONDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(
                options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.Value.DatabaseName);

            _Collection = mongoDatabase.GetCollection<Restaurants>(
                options.Value.CollectionName = "restaurants");
        }

        public async Task<List<Restaurants>> GetAsync() =>
            await _Collection.Find(_ => true).ToListAsync();
        public async Task<Restaurants?> GetAsync(string id) =>
            await _Collection.Find(x => x._id == id).FirstOrDefaultAsync();
    }
}
