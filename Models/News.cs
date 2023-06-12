using Newtonsoft.Json;

namespace NewsApplication.Models {
   
    public class News {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public object Category { get; set; }

        [JsonProperty("dateCreated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DateCreated { get; set; }

        [JsonProperty("dateModified", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DateModified { get; set; }

        [JsonProperty("htmlContent", NullValueHandling = NullValueHandling.Ignore)]
        public object HtmlContent { get; set; }

        [JsonProperty("imageAlt", NullValueHandling = NullValueHandling.Ignore)]
        public object ImageAlt { get; set; }

        [JsonProperty("imageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("storyFormat", NullValueHandling = NullValueHandling.Ignore)]
        public object StoryFormat { get; set; }

        [JsonProperty("storyId", NullValueHandling = NullValueHandling.Ignore)]
        public int StoryId { get; set; }

        [JsonProperty("storyUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string StoryUrl { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("videoUrl", NullValueHandling = NullValueHandling.Ignore)]
        public object VideoUrl { get; set; }

        [JsonProperty("storyType", NullValueHandling = NullValueHandling.Ignore)]
        public object StoryType { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public object Location { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public object Description { get; set; }

        [JsonProperty("buisnessName", NullValueHandling = NullValueHandling.Ignore)]
        public object BuisnessName { get; set; }

        [JsonProperty("buisnessContact", NullValueHandling = NullValueHandling.Ignore)]
        public object BuisnessContact { get; set; }

        [JsonProperty("validUntilDate", NullValueHandling = NullValueHandling.Ignore)]
        public object ValidUntilDate { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public object Status { get; set; }

        [JsonProperty("themeId", NullValueHandling = NullValueHandling.Ignore)]
        public object ThemeId { get; set; }

        [JsonProperty("updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public object UpdatedBy { get; set; }
    }


}
