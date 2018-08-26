namespace GitHubClient
{
    using System;
    using System.Collections.Generic;
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
        /// Prevents a default instance of the <see cref="GitHubApiClient" /> class from being created.
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
        /// Gets the name of current user.
        /// </summary>
        /// <param name="message">The message from client.</param>
        /// <returns>The username.</returns>
        public string GetCurrentUser(out string message)
        {
            message = string.Empty;
            string userURI = $"{this.baseUrl}user";
            HttpRequestMessage userRequest = this.GenerateBasicRequest(userURI);
            HttpResponseMessage userResponce = this.SendRequest(userRequest);
            
            switch (userResponce.StatusCode)
            {
                case HttpStatusCode.OK:
                {
                    string userJson = userResponce.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    User curentUser = JsonConvert.DeserializeObject<User>(userJson);
                    message = "Data fetched";
                    return curentUser.Name;
                }

                case HttpStatusCode.Unauthorized:
                {
                    message = "Please use another token";
                    return null;
                }

                default:
                {
                    message = $"Request ended with status code {userResponce.StatusCode}";
                    return null;
                }
            }
        } 

        /// <summary>
        /// Sets the authorization token.
        /// </summary>
        /// <param name="token">The authorization token.</param>
        public void SetAccessToken(string token)
        {
            this.accessToken = token;
        }

        /// <summary>
        /// Generates basic HttpRequestMessage object.
        /// </summary>
        /// <param name="uri">The uri of the endpoint.</param>
        /// <returns>The basic request object without content.</returns>
        public HttpRequestMessage GenerateBasicRequest(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);
            request.Headers.Add("User-Agent", "c#App");
            request.RequestUri = new Uri(uri);
            return request;
        }

        /// <summary>
        /// Sends specified request.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>The responce to request.</returns>
        public HttpResponseMessage SendRequest(HttpRequestMessage request)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responce = client.SendAsync(request).GetAwaiter().GetResult();
            return responce;
        }

        /// <summary>
        /// This method creates repository on gitHub.
        /// </summary>
        /// <param name="repositoryModel">The data about repository.</param>
        /// <returns>The result of operation.</returns>
        public string CreateRepository(CreateRepositoryModel repositoryModel)
        {
            var uri = $"{baseUrl}user/repos";
            HttpRequestMessage request = this.GenerateBasicRequest(uri);
            request.Method = HttpMethod.Post;
            string repoJson = JsonConvert.SerializeObject(repositoryModel);
            var content = new StringContent(repoJson);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Content = content;
            HttpResponseMessage responce = this.SendRequest(request);
            switch (responce.StatusCode)
            {
                case HttpStatusCode.Created: return "Repository created";
                default: return "Repositoty creation failed";
            }
        }

        /// <summary>
        /// Get list of repositories of specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="message">The message from client.</param>
        /// <returns>List of repositories.</returns>
        public List<Repository> GetUserRepositories(string username, out string message)
        {
            message = string.Empty;
            string uri = $"{baseUrl}users/{username}/repos";
            HttpRequestMessage request = this.GenerateBasicRequest(uri);
            HttpResponseMessage responce = this.SendRequest(request);
            string content = responce.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            switch (responce.StatusCode)
            {
                case HttpStatusCode.OK:
                {
                    message = "Successfil";
                    List<Repository> repositories = JsonConvert.DeserializeObject<List<Repository>>(content);
                    return repositories;
                }

                case HttpStatusCode.NotFound:
                {
                    message = "User not found";
                    return null;
                }

                default:
                {
                    message = $"request ended with status code {responce.StatusCode}";
                    return null;
                }
            }
        }

        /// <summary>
        /// Get repos of current user.
        /// </summary>
        /// <param name="message">The message from client.</param>
        /// <returns>List of repositories.</returns>
        public List<Repository> GetMyRepositories(out string message)
        {
            message = string.Empty;
            string uri = $"{baseUrl}user/repos";
            HttpRequestMessage request = this.GenerateBasicRequest(uri);
            HttpResponseMessage responce = this.SendRequest(request);
            string content = responce.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            switch (responce.StatusCode)
            {
                case HttpStatusCode.OK:
                {
                    message = "Successfil";
                    List<Repository> repositories = JsonConvert.DeserializeObject<List<Repository>>(content);
                    return repositories;
                }

                default:
                {
                    message = $"request ended with status code {responce.StatusCode}";
                    return null;
                }
            }
        }
    }
}
