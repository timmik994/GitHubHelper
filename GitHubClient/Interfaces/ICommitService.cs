namespace GitHubClient.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GitHubClient.Model;

    /// <summary>
    /// Service that works with commit data.
    /// </summary>
    public interface ICommitService
    {
        /// <summary>
        /// Gets commits from specified branch in specified repository.
        /// </summary>
        /// <param name="repository">The repository data.</param>
        /// <param name="branch">The branch data.</param>
        /// <returns>ClientResponce instance with collections of commits.</returns>
        Task<ClientResponce<IEnumerable<Commit>>> GetBranchCommits(BasicRepositoryData repository, Branch branch);

        /// <summary>
        /// Gets commits from specified branch in specified repository.
        /// </summary>
        /// <param name="username">The repository owner name.</param>
        /// <param name="repositoryName">The repository name.</param>
        /// <param name="branchName">The branch name.</param>
        /// <returns>ClientResponce instance with collections of commits.</returns>
        Task<ClientResponce<IEnumerable<Commit>>> GetBranchCommits(string username, string repositoryName, string branchName);
    }
}
