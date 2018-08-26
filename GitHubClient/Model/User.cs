namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents git hub user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets login of the user.
        /// </summary>
        [JsonProperty("login")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets url of user page on github.
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
