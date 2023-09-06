using HAKATON_Models.Models.Hotels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HAKATON_Models.Services
{
    public class HotelsService
    {
        private readonly IMongoCollection<Hotels> _Collection;

        public HotelsService(
            IOptions<HAKATONDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(
                options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.Value.DatabaseName);

            _Collection = mongoDatabase.GetCollection<Hotels>(
                options.Value.CollectionName = "hotels");
        }

        public async Task<List<Hotels>> GetAsync() =>
            await _Collection.Find(_ => true).ToListAsync();
        public async Task<Hotels?> GetAsync(string id) =>
            await _Collection.Find(x => x._id == id).FirstOrDefaultAsync();
        public async Task<ActionResult<IEnumerable<Hotels>>> GetPag(int pageNumber, int pageSize) =>
            await _Collection.Find(_ => true)
            .Skip((pageNumber - 1) * pageSize).Limit(pageSize).ToListAsync();
    }
}
