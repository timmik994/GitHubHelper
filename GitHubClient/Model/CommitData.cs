namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Commit data from commit json property.
    /// </summary>
    public class CommitData
    {
        /// <summary>
        /// Gets or sets the person who did the commit and data of commit.
        /// </summary>
        [JsonProperty("committer")]
        public CommitAuthor Comitter { get; set; }
    }
}
