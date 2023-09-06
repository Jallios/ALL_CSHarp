using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Routes
{
    [BsonIgnoreExtraElements]
    public class DictionaryData_Routes
    {
        public List<object>? type_audio_guide { get; set; }
        public string? region { get; set; }
        public List<string>? information_pages { get; set; }
        public List<ImageExplorePreview>? image_explore_preview { get; set; }
        public List<object>? image_detailed_page_main { get; set; }
        public List<string>? tags_main_screen { get; set; }
        public int? rp_price_id { get; set; }
        public List<Image>? images { get; set; }
        public Route_Routes? route { get; set; }
        public string? description { get; set; }
        public int? sort { get; set; }
        public string? time { get; set; }
        public int? packet_price { get; set; }
        public List<object>? route_tags { get; set; }
        public string? city { get; set; }
        public bool? import_denied { get; set; }
        public string? title { get; set; }
    }
}
