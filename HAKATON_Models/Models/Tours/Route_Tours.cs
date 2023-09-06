using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Tours
{
    [BsonIgnoreExtraElements]
    public class Route_Tours
    {
        public string? title { get; set; }
        public List<object>? events { get; set; }
    }
}
