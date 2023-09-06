using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models
{
    [BsonIgnoreExtraElements]
    public class ImageDetailedPageMain
    {
        public Source? source { get; set; }
    }
}
