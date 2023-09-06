using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Restaurants
{
    [BsonIgnoreExtraElements]
    public class Tue
    {
        public object? startTime { get; set; }
        public object? endTime { get; set; }
        public List<object>? breaks { get; set; }
        public bool? closed { get; set; }
    }
}
