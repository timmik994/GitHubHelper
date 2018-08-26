﻿namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents repository from github.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// Gets or sets name of repository.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets date when repository was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets repository description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Get string representation of the class.
        /// </summary>
        /// <returns>String representation of class data.</returns>
        public override string ToString()
        {
            return $"{this.Name}  {this.CreatedAt}  {this.Description}";
        }
    }
}
