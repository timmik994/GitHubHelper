using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GitHubClient.Model
{
    /// <summary>
    /// User premissons in repository.
    /// </summary>
    public class UserPremissions
    {
        /// <summary>
        /// Gets or sets a value indicating wether current user
        /// has admin privelegies.
        /// </summary>
        [JsonProperty("admin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wether current user
        /// can push in this repository.
        /// </summary>
        [JsonProperty("push")]
        public bool CanPush { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wether current user
        /// can pull this repository.
        /// </summary>
        [JsonProperty("pull")]
        public bool CanPull { get; set; }
    }
}
