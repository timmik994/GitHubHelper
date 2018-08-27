namespace GitHubHelper.Commands
{
    using System;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// Command that creates new repository.
    /// </summary>
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
        /// Asks name and description of repository.
        /// </summary>
        public override void GetParameters()
        {
            Console.WriteLine("Name of the repository");
            string repositoryName = Console.ReadLine();
            Console.WriteLine("Description:");
            string repositoryDescription = Console.ReadLine();
            this.repositoryData = new CreateRepositoryModel(repositoryName, repositoryDescription);
        }

        /// <summary>
        /// Creates repository using gitHub client.
        /// </summary>
        public override void RunCommand()
        {
            GitHubApiClient gitHubClient = GitHubApiClient.GetInstance();
            this.responce = gitHubClient.CreateRepository(this.repositoryData);
        }

        /// <summary>
        /// Shows result into console.
        /// </summary>
        public override void ShowResult()
        {
           Console.WriteLine(this.responce);
        }
    }
}
