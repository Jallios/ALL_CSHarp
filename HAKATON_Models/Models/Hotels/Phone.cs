using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Hotels
{
    [BsonIgnoreExtraElements]
    public class Phone
    {
        public string? name { get; set; }
        public string? number { get; set; }
    }
}
