using System;
using GitHubClient;
using GitHubClient.Model;

namespace GitHubHelper.Commands
{
    /// <summary>
    /// The actions to create repository.
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
        /// Asks nesessary parameters from console.
        /// </summary>
        public override void GetParameters()
        {
            Console.WriteLine("Name of the repository");
            string repositoryName = Console.ReadLine();
            Console.WriteLine("Description:");
            string repositoryDescription = Console.ReadLine();
            repositoryData=new CreateRepositoryModel(repositoryName, repositoryDescription);
        }

        /// <summary>
        /// Creates repository using gitHub client.
        /// </summary>
        public override void RunCommand()
        {
            GitHubApiClient gitHubClient = GitHubApiClient.GetInstance();
            this.responce = gitHubClient.CreateRepository(repositoryData);
        }

        /// <summary>
        /// Shows result into console.
        /// </summary>
        public override void ShowResult()
        {
           Console.WriteLine(responce);
        }
    }
}
