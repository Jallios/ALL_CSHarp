using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Tours
{
    [BsonIgnoreExtraElements]
    public class TourComposition
    {
        public string? title { get; set; }
        public List<string>? list { get; set; }
    }
}
