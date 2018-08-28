namespace GitHubHelper.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// Command to get repositories of branch.
    /// </summary>
    public class BranchCommitsCommand : AbstractCommand
    {
        /// <summary>
        /// String that prints between commits.
        /// </summary>
        private const string COMMITDELIMETER = "_________________________";

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
        /// The name of the branch.
        /// </summary>
        private string branchName;

        /// <summary>
        /// The message from gitHub client.
        /// </summary>
        private string message;

        /// <summary>
        /// The list of commits from git hub.
        /// </summary>
        private List<Commit> commits;

        /// <summary>
        /// Get the parameters to run command.
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
            Console.WriteLine("Enter the branch name");
            this.branchName = Console.ReadLine();
        }

        /// <summary>
        /// Gets the list of commits from branch.
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
                this.commits =
                    gitHubClient.GetBranchCommits(this.username, this.repoName, this.branchName, out this.message);
            }
        }

        /// <summary>
        /// Shows list of commits or message if commits is null.
        /// </summary>
        public override void ShowResult()
        {
            if (this.commits == null)
            {
                Console.WriteLine(this.message);
            }
            else
            {
                Console.WriteLine("commits:");
                foreach (var item in this.commits)
                {
                    Console.WriteLine(BranchCommitsCommand.COMMITDELIMETER);
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
