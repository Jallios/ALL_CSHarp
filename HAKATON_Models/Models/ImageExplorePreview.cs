using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models
{
    [BsonIgnoreExtraElements]
    public class ImageExplorePreview
    {
        public Source? source { get; set; }
    }
}
