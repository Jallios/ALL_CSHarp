using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Routes
{
    [BsonIgnoreExtraElements]
    public class Routes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        public DictionaryData_Routes? dictionary_data { get; set; }
    }
}
