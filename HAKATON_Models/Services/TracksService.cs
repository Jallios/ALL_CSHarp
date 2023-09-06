using HAKATON_Models.Models.Tracks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HAKATON_Models.Services
{
    public class TracksService
    {
        private readonly IMongoCollection<Tracks> _Collection;

        public TracksService(
            IOptions<HAKATONDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(
                options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.Value.DatabaseName);

            _Collection = mongoDatabase.GetCollection<Tracks>(
                options.Value.CollectionName = "tracks");
        }

        public async Task<List<Tracks>> GetAsync() =>
            await _Collection.Find(_ => true).ToListAsync();
        public async Task<Tracks?> GetAsync(string id) =>
            await _Collection.Find(x => x._id == id).FirstOrDefaultAsync();
    }
}

