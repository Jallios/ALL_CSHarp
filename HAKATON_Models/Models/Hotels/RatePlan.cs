using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Hotels
{
    [BsonIgnoreExtraElements]
    public class RatePlan
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public string? integration_id { get; set; }
    }
}
