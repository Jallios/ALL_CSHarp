using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models
{
    [BsonIgnoreExtraElements]
    public class Source
    {
        [BsonRepresentation(BsonType.String)]
        public string? id { get; set; }
    }
}
