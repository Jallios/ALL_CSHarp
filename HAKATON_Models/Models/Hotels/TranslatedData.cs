using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Hotels
{
    [BsonIgnoreExtraElements]
    public class TranslatedData
    {
        public En? en { get; set; }
        public Es? es { get; set; }
    }
}
