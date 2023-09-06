using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Restaurants
{
    [BsonIgnoreExtraElements]
    public class All
    {
        public string? startTime { get; set; }
        public string? endTime { get; set; }
        public List<object>? breaks { get; set; }
        public object? closed { get; set; }
    }
}
