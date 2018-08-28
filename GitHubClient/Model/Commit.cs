namespace GitHubClient.Model
{
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Commit in gitHub repository.
    /// </summary>
    public class Commit
    {
        /// <summary>
        /// Gets or sets sha of commit.
        /// </summary>
        [JsonProperty("sha")]
        public string Sha { get; set; }

        /// <summary>
        /// Gets or sets the data about author of the commit.
        /// </summary>
        [JsonProperty("commit")]
        public CommitData CommitAuthorData { get; set; }

        /// <summary>
        /// Gets or sets commit author's user object.
        /// </summary>
        [JsonProperty("author")]
        public User CommitUserObject { get; set; }

        /// <summary>
        /// Creates string representation of object.
        /// </summary>
        /// <returns>String representation of object.</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"sha: {Sha}");
            str.AppendLine($"date: {CommitAuthorData.Comitter.Date}");
            str.AppendLine($"commiter: {CommitUserObject.Login}");
            str.AppendLine($"email: {CommitAuthorData.Comitter.Email}");
            return str.ToString();
        }
    }
}
