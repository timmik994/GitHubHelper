﻿namespace GitHubHelper.Commands
{
    using System;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// Command that creates new repository.
    /// </summary>
    [Command("create", "Creates the repository.")]
    public class CreateRepoCommand : AbstractCommand
    {
        /// <summary>
        /// The data of new repository.
        /// </summary>
        private CreateRepositoryModel repositoryData;

        /// <summary>
        /// The responce of the system.
        /// </summary>
        private string responce;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRepoCommand" /> class.
        /// </summary>
        /// <param name="consoleHelper">The ConsoleHelper instance.</param>
        /// <param name="gitHubClient">The GitHubClient instance.</param>
        public CreateRepoCommand(ConsoleWorker consoleHelper, GitHubApiClient gitHubClient) : base(consoleHelper, gitHubClient)
        {
        }

        /// <summary>
        /// Asks name and description of repository.
        /// </summary>
        public override void GetParameters()
        {
            string repositoryName = this.ConslWorker.AskStringParam("Name of the repository");
            string repositoryDescription = this.ConslWorker.AskStringParam("Description:");
            this.repositoryData = new CreateRepositoryModel(repositoryName, repositoryDescription);
        }

        /// <summary>
        /// Creates repository using gitHub client.
        /// </summary>
        public override void RunCommand()
        {
            this.responce = this.GitHubClient.CreateRepository(this.repositoryData);
        }

        /// <summary>
        /// Shows result into console.
        /// </summary>
        public override void ShowResult()
        {
           this.ConslWorker.WriteInConsole(this.responce);
        }
    }
}
