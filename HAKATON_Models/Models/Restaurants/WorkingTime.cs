using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Restaurants
{
    [BsonIgnoreExtraElements]
    public class WorkingTime
    {
        public Days? days { get; set; }
        public All? all { get; set; }
    }
}
