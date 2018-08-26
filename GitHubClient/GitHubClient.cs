namespace GitHubClient
{
    /// <summary>
    /// This class contains methods to communicate with gitHub.
    /// </summary>
    public class GitHubApiClient
    {
        /// <summary>
        /// The instance of GitHubClient.
        /// </summary>
        private static GitHubApiClient instance;

        /// <summary>
        /// Access token for GitHub.
        /// </summary>
        private string accessToken;

        /// <summary>
        /// Prevents a default instance of the <see cref="GitHubApiClient" /> class from being created
        /// </summary>
        private GitHubApiClient()
        {
        }

        /// <summary>
        /// Gets the instance of gitHubClient.
        /// </summary>
        /// <returns>Instance of <see cref="GitHubApiClient" /> class.</returns>
        public static GitHubApiClient GetInstance()
        {
            if (GitHubApiClient.instance == null)
            {
                GitHubApiClient.instance = new GitHubApiClient();
            }

            return GitHubApiClient.instance;
        }

        /// <summary>
        /// Sets the authorization token.
        /// </summary>
        /// <param name="token">The authorizationToken</param>
        public void SetAccessToken(string token)
        {
            this.accessToken = token;
        }



    }
}
