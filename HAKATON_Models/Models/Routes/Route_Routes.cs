using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Routes
{
    [BsonIgnoreExtraElements]
    public class Route_Routes
    {
        public List<string>? dictionaries { get; set; }
        public List<Selected>? selected { get; set; }
        public List<string>? active { get; set; }
    }
}
