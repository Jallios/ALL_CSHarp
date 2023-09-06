using HAKATON_Models.Models.Tours;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HAKATON_Models.Services
{
    public class ToursService
    {
        private readonly IMongoCollection<Tours> _Collection;

        public ToursService(
            IOptions<HAKATONDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(
                options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.Value.DatabaseName);

            _Collection = mongoDatabase.GetCollection<Tours>(
                options.Value.CollectionName = "tours");
        }

        public async Task<List<Tours>> GetAsync() =>
            await _Collection.Find(_ => true).ToListAsync();
        public async Task<Tours?> GetAsync(string id) =>
            await _Collection.Find(x => x._id == id).FirstOrDefaultAsync();
    }
}
