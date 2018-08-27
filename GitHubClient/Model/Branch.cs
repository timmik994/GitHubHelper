namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Branch data getted from branch list of git repository.
    /// </summary>
    public class Branch
    {
        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
