namespace GitHubClient.Interfaces
{
    using System.Threading.Tasks;
    using GitHubClient.Model;

    /// <summary>
    /// Service that works with users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets data about current user.
        /// </summary>
        /// <returns>ClientResponce instance with full data of current user.</returns>
        Task<ClientResponce<FullUserData>> GetCurrentUser();

        /// <summary>
        /// Get full data about user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>ClientResponce instance with full data about specified user.</returns>
        Task<ClientResponce<FullUserData>> GetFullUserData(string username);

        /// <summary>
        /// Get full user data about specified user.
        /// </summary>
        /// <param name="userData">The basic user data.</param>
        /// <returns>ClientResponce instance with full data about specified user.</returns>
        Task<ClientResponce<FullUserData>> GetFullUserData(BasicUserData userData);
    }
}
