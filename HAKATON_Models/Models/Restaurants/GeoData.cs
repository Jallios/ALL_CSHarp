using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Restaurants
{
    [BsonIgnoreExtraElements]
    public class GeoData
    {
        public List<double>? coordinates { get; set; }
        public double? center_distance { get; set; }
    }
}
