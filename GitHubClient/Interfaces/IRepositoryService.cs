namespace GitHubClient.Interfaces
{
    using System.Collections.Generic;
    using GitHubClient.Model;

    /// <summary>
    /// Service that works with repositories.
    /// </summary>
    public interface IRepositoryService
    {
        /// <summary>
        /// Gets repositories of specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>with with collection of repositories of specified user.</returns>
        ClientResponce<IEnumerable<BasicRepositoryData>> GetUserRepositories(string username);

        /// <summary>
        /// Gets repositories of specified user.
        /// </summary>
        /// <param name="userData">The basic data of the user.</param>
        /// <returns>ClientResponce instance with cllection of repositories of specified user.</returns>
        ClientResponce<IEnumerable<BasicRepositoryData>> GetUserRepositories(BasicUserData userData);

        /// <summary>
        /// Gets full data of repository.
        /// </summary>
        /// <param name="repositoryData">Basic repository data.</param>
        /// <returns>ClientResponce instance with full data of repository.</returns>
        ClientResponce<FullRepositoryData> GetFullRepositoryData(BasicRepositoryData repositoryData);
    }
}
