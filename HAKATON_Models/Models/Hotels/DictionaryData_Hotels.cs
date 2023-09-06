using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Hotels
{
    [BsonIgnoreExtraElements]
    public class DictionaryData_Hotels
    {
        public GeoData_Hotels? geo_data { get; set; }
        public List<ImageExplorePreview>? image_explore_preview { get; set; }
        public List<ImageDetailedPageMain>? image_detailed_page_main { get; set; }
        public List<Image>? images { get; set; }
        public List<Room>? rooms { get; set; }
        public string? address { get; set; }
        public List<object>? services { get; set; }
        public List<string>? facility_services { get; set; }
        public List<object>? beach_services { get; set; }
        public List<object>? entertainment_services { get; set; }
        public List<object>? fitness_services { get; set; }
        public List<object>? meals { get; set; }
        public List<string>? common_services { get; set; }
        public string? integration_id { get; set; }
        public string? partner_system_type { get; set; }
        public List<Phone>? phones { get; set; }
        public string? email { get; set; }
        public string? stars { get; set; }
        public string? partner { get; set; }
        public string? region { get; set; }
        public string? city { get; set; }
        public string? description { get; set; }
        public string? title { get; set; }
        public bool? import_denied { get; set; }
        public string? time_zone { get; set; }
    }
}
