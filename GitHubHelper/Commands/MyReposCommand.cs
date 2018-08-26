namespace GitHubHelper.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// This class represents command, that
    /// gets repositories of specified user.
    /// </summary>
    public class MyReposCommand : AbstractCommand
    {
        /// <summary>
        /// The repositories getted from github.
        /// </summary>
        private List<Repository> repositories;

        /// <summary>
        /// The message from client;
        /// </summary>
        private string message;

        /// <summary>
        /// Asks username from user.
        /// </summary>
        public override void GetParameters()
        {
        }

        /// <summary>
        /// Gets the repositories.
        /// </summary>
        public override void RunCommand()
        {
            GitHubApiClient client = GitHubApiClient.GetInstance();
            this.repositories = client.GetMyRepositories(out this.message);
        }

        /// <summary>
        /// Shows results in console.
        /// </summary>
        public override void ShowResult()
        {
            if (this.repositories == null)
            {
                Console.WriteLine(this.message);
            }
            else
            {
                IEnumerable<string> reposData = this.repositories.Select(rep => rep.ToString());
                foreach (var s in reposData)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
