using HAKATON_Models.Models;
using HAKATON_Models.Models.Routes;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HAKATON_Models.Services
{
    public class RoutesService
    {
        private readonly IMongoCollection<Routes> _Collection;

        public RoutesService(
            IOptions<HAKATONDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(
                options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.Value.DatabaseName);

            _Collection = mongoDatabase.GetCollection<Routes>(
                options.Value.CollectionName = "routes");
        }

        public async Task<List<Routes>> GetAsync() =>
            await _Collection.Find(_ => true).ToListAsync();
        public async Task<Routes?> GetAsync(string id) =>
            await _Collection.Find(x => x._id == id).FirstOrDefaultAsync();
    }
}
