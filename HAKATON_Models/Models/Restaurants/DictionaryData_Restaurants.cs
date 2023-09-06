using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Restaurants
{
    [BsonIgnoreExtraElements]
    
    public class DictionaryData_Restaurants
    {
        public List<object>? showcase_filter { get; set; }
        public string? parser_source { get; set; }
        public List<object>? hp_images { get; set; }
        public bool? russpass_recommendation { get; set; }
        public List<object>? type_audio_guide { get; set; }
        public List<object>? images360 { get; set; }
        public List<Image>? images { get; set; }
        public List<ImageDetailedPageMain>? image_detailed_page_main { get; set; }
        public List<ImageExplorePreview>? image_explore_preview { get; set; }
        public List<object>? promo { get; set; }
        public bool? can_reserve { get; set; }
        public int? avg_time_visit { get; set; }
        public List<string>? tags_main_screen { get; set; }
        public List<object>? cg_recommendations { get; set; }
        public List<string>? tags { get; set; }
        public int? bill { get; set; }
        public List<object>? icons { get; set; }
        public string? partner { get; set; }
        public List<object>? rest_services { get; set; }
        public List<object>? partner_subtype { get; set; }
        public List<object>? chain { get; set; }
        public List<string>? cuisines { get; set; }

        [BsonIgnore]
        [BsonElement("partner_type")]
        public List<object>? partner_type { get; set; }
        public List<object>? menu_type { get; set; }
        public List<object>? children { get; set; }
        public List<object>? guides { get; set; }

        [BsonIgnore]
        [BsonElement("phones")]
        public List<string>? phones { get; set; }

        public List<object>? district { get; set; }
        public List<object>? metro { get; set; }
        public List<string>? city { get; set; }
        public List<object>? subcategories { get; set; }
        public string? region { get; set; }
        public List<object>? country { get; set; }
        public string? address { get; set; }
        public WorkingTime? working_time { get; set; }
        public GeoData? geo_data { get; set; }
        public string? description { get; set; }
        public string? title { get; set; }
        public bool? import_denied { get; set; }
    }
}
