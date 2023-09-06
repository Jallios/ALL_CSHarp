using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HAKATON_Models.Models.Tours
{
    [BsonIgnoreExtraElements]
    public class DictionaryData_Tours
    {
        public List<object>? type_audio_guide { get; set; }
        public string? region { get; set; }
        public string? partner { get; set; }
        public List<ImageDetailedPageMain>? image_detailed_page_main { get; set; }
        public List<ImageExplorePreview>? image_explore_preview { get; set; }
        public List<Image>? images { get; set; }
        public List<TourComposition>? tour_composition { get; set; }
        public List<Route_Tours>? route { get; set; }
        public List<string>? tags { get; set; }
        public List<string>? tags_main_screen { get; set; }
        public DateTime? season_end { get; set; }
        public DateTime? season_start { get; set; }
        public string? minGroupCount { get; set; }
        public string? price { get; set; }
        public string? hotel_stars { get; set; }
        public string? min_age { get; set; }
        public string? complexity { get; set; }
        public int? days { get; set; }
        public int? nights { get; set; }
        public string? city { get; set; }
        public int? sort { get; set; }
        public string? program { get; set; }
        public string? description { get; set; }
        public string? title { get; set; }

        [JsonProperty("pravila-soglasovaniya")]
        public bool? pravilasoglasovaniya { get; set; }
    }
}
