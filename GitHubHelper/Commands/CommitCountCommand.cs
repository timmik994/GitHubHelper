namespace GitHubHelper.Commands
{
    using System;
    using System.Collections.Generic;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// Command that gets count of commits.
    /// </summary>
    public class CommitCountCommand : AbstractCommand
    {
        /// <summary>
        /// The username.
        /// </summary>
        private string username;

        /// <summary>
        /// Is calculates count in all repositories in user list.
        /// </summary>
        private bool inAllRepos;

        /// <summary>
        /// Is current user is owner of repository.
        /// </summary>
        private bool isYourRepo;

        /// <summary>
        /// The name of the repo.
        /// </summary>
        private string repoName;

        /// <summary>
        /// The message from gitHub client.
        /// </summary>
        private string message;

        /// <summary>
        /// Count of commits.
        /// </summary>
        private int commitsCount;

        /// <summary>
        /// Gets the parameters to run command.
        /// </summary>
        public override void GetParameters()
        {
            Console.WriteLine("In all repositories?");
            this.inAllRepos = this.GetUserAgree();
            if (!this.inAllRepos)
            {
                Console.WriteLine("Enter name of repository");
                this.repoName = Console.ReadLine();
                Console.WriteLine("Your repository?");
                this.isYourRepo = this.GetUserAgree();
                if (!this.isYourRepo)
                {
                    Console.WriteLine("Enter repository owner");
                    this.username = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// If repoName is not empty we get count of commits from that repo.
        /// Otherwise we get commits from all your repos.
        /// </summary>
        public override void RunCommand()
        {
            GitHubApiClient gitHubClient = GitHubApiClient.GetInstance();
            if (this.isYourRepo)
            {
                this.username = gitHubClient.GetCurrentUser(out this.message);
                if (this.message != GitHubApiClient.SUCCESSMESSAGE)
                {
                    return;
                }
            }

            if (!this.inAllRepos)
            {
                this.commitsCount = this.GetCommitCountInRepo(this.repoName, this.username);
            }
            else
            {
                List<Repository> repositories = gitHubClient.GetMyRepositories(out this.message);
                if (repositories != null)
                {
                    foreach (var repo in repositories)
                    {
                        this.commitsCount += this.GetCommitCountInRepo(repo.Name, repo.Owner.Login);
                    }
                }
            }
        }

        /// <summary>
        /// If all requests are successful Shows count of commits.
        /// Otherwise says that something is wrong.
        /// </summary>
        public override void ShowResult()
        {
            if (this.message == GitHubApiClient.SUCCESSMESSAGE)
            {
                Console.WriteLine($"Count of commits: {this.commitsCount}");
            }
            else
            {
                Console.WriteLine("The are some problems with requests.");
            }
        }

        /// <summary>
        /// Gets commit count from specified repository.
        /// </summary>
        /// <param name="repositoryName">The name of repository.</param>
        /// <param name="ownreUsername">the usernameof repository owner.</param>
        /// <returns>Count of commits in repository.</returns>
        private int GetCommitCountInRepo(string repositoryName, string ownreUsername)
        {
            GitHubApiClient gitHubClient = GitHubApiClient.GetInstance();
            List<Commit> commits = gitHubClient.GetReposiroryCommits(ownreUsername, repositoryName, out this.message);
            if (commits != null)
            {
                return commits.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
