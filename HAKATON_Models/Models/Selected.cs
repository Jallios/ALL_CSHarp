using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models
{
    [BsonIgnoreExtraElements]
    public class Selected
    { 
        public string? id { get; set; }
        public bool? active { get; set; }
    }
}
