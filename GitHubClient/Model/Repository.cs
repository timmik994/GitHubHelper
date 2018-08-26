using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubClient.Model
{
    /// <summary>
    /// This class represents repository from github.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// The author of the repository.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// The name of repository.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date when repository was created.
        /// </summary>
        public  string CreatedAt { get; set; }
    }
}
