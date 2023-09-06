using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models
{
    [BsonIgnoreExtraElements]
    public class Image
    {
        public Source? source { get; set; }
    }
}
