﻿namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// The data needed for create repository.
    /// </summary>
    public class CreateRepositoryModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRepositoryModel" /> class.
        /// </summary>
        /// <param name="name">The name of the repository.</param>
        /// <param name="description">The description of new repository.</param>
        public CreateRepositoryModel(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets name of the repository.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description of new repository.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
