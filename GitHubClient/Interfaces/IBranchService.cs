using System;
using System.Collections.Generic;
using System.Text;
using GitHubClient.Model;

namespace GitHubClient.Interfaces
{
    public interface IBranchService
    {
        /// <summary>
        /// Gets branches list of specified repository.
        /// </summary>
        /// <param name="username">The name of repository owner.</param>
        /// <param name="repositoryName">The repository name.</param>
        /// <returns>ClientResponce instance with collection of branches.</returns>
        ClientResponce<IEnumerable<Branch>> GetBranchList(string username, string repositoryName);

        /// <summary>
        /// Gets branches list of specified repository.
        /// </summary>
        /// <param name="repositoryData">The data of repository.</param>
        /// <returns>ClientResponce instance with collection of branches.</returns>
        ClientResponce<IEnumerable<Branch>> GetBranchList(BasicRepositoryData repositoryData);
    }
}
