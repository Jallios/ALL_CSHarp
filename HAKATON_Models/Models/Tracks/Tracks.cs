using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Tracks
{
    [BsonIgnoreExtraElements]
    public class Tracks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        public DictionaryData_Tracks? dictionary_data { get; set; }
    }
}
