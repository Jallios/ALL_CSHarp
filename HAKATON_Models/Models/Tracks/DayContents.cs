using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Tracks
{
    [BsonIgnoreExtraElements]
    public class DayContents
    {
        public List<string>? dictionaries { get; set; }
        public List<Selected>? selected { get; set; }
        public List<string>? active { get; set; }
    }
}
