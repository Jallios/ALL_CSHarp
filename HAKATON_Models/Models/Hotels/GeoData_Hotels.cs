using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Hotels
{
    [BsonIgnoreExtraElements]
    public class GeoData_Hotels
    {
        public List<double>? coordinates { get; set; }
        public double? center_distance { get; set; }
    }
}
