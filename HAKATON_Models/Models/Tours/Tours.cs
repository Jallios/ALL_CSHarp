using HAKATON_Models.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Tours
{
    [BsonIgnoreExtraElements]
    public class Tours
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public DictionaryData_Tours? dictionary_data { get; set; }
    }
}
