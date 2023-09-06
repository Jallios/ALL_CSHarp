using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Hotels
{
    [BsonIgnoreExtraElements]
    public class Room
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public List<string>? amenities { get; set; }
        public List<Image>? images { get; set; }
        public string? integration_id { get; set; }
        public List<RatePlan>? rate_plans { get; set; }
        public TranslatedData? translated_data { get; set; }
    }
}
