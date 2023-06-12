using Newtonsoft.Json;

namespace NewsApplication.Models {
    public class Token {
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; }

        [JsonProperty("id_token", NullValueHandling = NullValueHandling.Ignore)]
        public string IdToken { get; set; }

        [JsonProperty("token_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenType { get; set; }

        [JsonProperty("not_before", NullValueHandling = NullValueHandling.Ignore)]
        public int NotBefore { get; set; }

        [JsonProperty("expires_in", NullValueHandling = NullValueHandling.Ignore)]
        public int ExpiresIn { get; set; }

        [JsonProperty("expires_on", NullValueHandling = NullValueHandling.Ignore)]
        public int ExpiresOn { get; set; }

        [JsonProperty("resource", NullValueHandling = NullValueHandling.Ignore)]
        public string Resource { get; set; }

        [JsonProperty("id_token_expires_in", NullValueHandling = NullValueHandling.Ignore)]
        public int IdTokenExpiresIn { get; set; }

        [JsonProperty("profile_info", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfileInfo { get; set; }

        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        [JsonProperty("refresh_token", NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshToken { get; set; }

        [JsonProperty("refresh_token_expires_in", NullValueHandling = NullValueHandling.Ignore)]
        public int RefreshTokenExpiresIn { get; set; }
    }

}
