namespace GitHubHelper.Commands
{
    using System;
    using System.Collections.Generic;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// This class represents command, that
    /// gets repositories of specified user.
    /// </summary>
    public class UserReposCommand : AbstractCommand
    {
        /// <summary>
        /// The repositories getted from github.
        /// </summary>
        private List<Repository> repositories;

        /// <summary>
        /// The username.
        /// </summary>
        private string username;

        /// <summary>
        /// The message from client;
        /// </summary>
        private string message;

        /// <summary>
        /// Asks username from user.
        /// </summary>
        public override void GetParameters()
        {
            Console.WriteLine("Enter the username");
            this.username = Console.ReadLine();
        }
        
        /// <summary>
        /// Gets the repositories.
        /// </summary>
        public override void RunCommand()
        {
            GitHubApiClient client = GitHubApiClient.GetInstance();
            this.repositories = client.GetUserRepositories(this.username, out this.message);
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
                foreach (var repo in repositories)
                {
                    Console.WriteLine(repo.ToString());
                }
            }
        }
    }
}
