using MongoDB.Bson.Serialization.Attributes;

namespace HAKATON_Models.Models.Tracks
{
    [BsonIgnoreExtraElements]
    public class DictionaryData_Tracks
    {
        public List<object>? type_audio_guide { get; set; }
        public List<object>? information_pages { get; set; }
        public string? region { get; set; }
        public List<ImageExplorePreview>? image_explore_preview { get; set; }
        public List<Image>? images { get; set; }
        public List<object>? image_detailed_page_main { get; set; }
        public List<Route_Tracks>? route { get; set; }
        public int? sort { get; set; }
        public List<string>? tags_main_screen { get; set; }
        public List<string>? tags { get; set; }
        public int? price { get; set; }
        public int? duration_hours { get; set; }
        public int? days_count { get; set; }
        public string? description { get; set; }
        public bool? import_denied { get; set; }
        public string? type { get; set; }
        public string? city { get; set; }
        public string? title { get; set; }
    }
}
