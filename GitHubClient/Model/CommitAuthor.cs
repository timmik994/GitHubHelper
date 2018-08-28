namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Commiter in commit data.
    /// </summary>
    public class CommitAuthor
    {
        /// <summary>
        /// Gets or sets name of the commiter.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Date of the commit.
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets email of commiter.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
