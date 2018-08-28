﻿namespace GitHubHelper.Commands
{
    using System;
    using System.Collections.Generic;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// Command that gets the branches list from repo.
    /// </summary>
    public class GetBranchesCommand : AbstractCommand
    {
        /// <summary>
        /// The username.
        /// </summary>
        private string username;

        /// <summary>
        /// Is current user is owner of repository.
        /// </summary>
        private bool isYourRepo;

        /// <summary>
        /// The name of the repo.
        /// </summary>
        private string repoName;

        /// <summary>
        /// List of branches.
        /// </summary>
        private List<Branch> branches;

        /// <summary>
        /// The message from gitHub client.
        /// </summary>
        private string message;

        /// <summary>
        /// Gets the parameters for command.
        /// </summary>
        public override void GetParameters()
        {
            Console.WriteLine("Your repository?");
            this.isYourRepo = this.GetUserAgree();
            if (!this.isYourRepo)
            {
                Console.WriteLine("Enter the username ");
                this.username = Console.ReadLine();
            }

            Console.WriteLine("Enter name of repository");
            this.repoName = Console.ReadLine();
        }

        /// <summary>
        /// Gets list of branches from one repository.
        /// </summary>
        public override void RunCommand()
        {
            GitHubApiClient gitHubClient = GitHubApiClient.GetInstance();
            if (this.isYourRepo)
            {
                this.username = gitHubClient.GetCurrentUser(out this.message);
            }

            if (this.message == GitHubApiClient.SUCCESSMESSAGE)
            {
                this.branches = gitHubClient.GetBranchesList(this.username, this.repoName, out this.message);
            }
        }

        /// <summary>
        /// Shows list of branches, or message if branches is null.
        /// </summary>
        public override void ShowResult()
        {
            if (this.branches == null)
            {
                Console.WriteLine(this.message);
            }
            else
            {
                Console.WriteLine("List of branches:");
                foreach (var item in this.branches)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
