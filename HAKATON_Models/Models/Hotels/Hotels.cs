using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Hotels
{
    [BsonIgnoreExtraElements]
    public class Hotels
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        public DictionaryData_Hotels? dictionary_data { get; set; }
    }
}
