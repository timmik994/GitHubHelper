namespace GitHubClient
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using GitHubClient.Model;
    using Newtonsoft.Json;

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
        /// This is basic url to connect gitHubApi.
        /// </summary>
        private readonly string baseUrl = "https://api.github.com/";

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

        /// <summary>
        /// This method creates repository on gitHub
        /// </summary>
        /// <param name="repositoryModel">The data about repository.</param>
        /// <returns>The result of operation.</returns>
        public string CreateRepository(CreateRepositoryModel repositoryModel)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);
            request.Headers.Add("User-Agent","c#App");
            request.RequestUri = new Uri($"{baseUrl}user/repos");
            request.Method = HttpMethod.Post;
            string repoJson = JsonConvert.SerializeObject(repositoryModel);
            var content = new StringContent(repoJson);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Content = content;
            HttpResponseMessage responce = client.SendAsync(request).GetAwaiter().GetResult();
            switch (responce.StatusCode)
            {
                case HttpStatusCode.Created: return "Repository created";
                default : return "Repositoty creation failed";
            }
        }
    }
}
