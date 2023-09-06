using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Tracks
{
    [BsonIgnoreExtraElements]
    public class Route_Tracks
    {
        public string? title { get; set; }
        public DayContents? day_contents { get; set; }
        public List<object>? recommended_hotels { get; set; }
    }
}
