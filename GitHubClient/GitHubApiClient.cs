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
    /// GitHub client class.
    /// </summary>
    public class GitHubApiClient
    {
        /// <summary>
        /// Message from success operation.
        /// </summary>
        public const string SUCCESSMESSAGE = "success";

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
                    message = GitHubApiClient.SUCCESSMESSAGE;
                    return curentUser.Login;
                }

                case HttpStatusCode.Unauthorized:
                {
                    message = "Please use another token";
                    return string.Empty;
                }

                default:
                {
                    message = $"Request ended with status code {userResponce.StatusCode}";
                    return string.Empty;
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
        /// Gets list of repositories of specified user.
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
            switch (responce.StatusCode)
            {
                case HttpStatusCode.OK:
                {
                    message = GitHubApiClient.SUCCESSMESSAGE;
                    string content = responce.Content.ReadAsStringAsync().GetAwaiter().GetResult();
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
            switch (responce.StatusCode)
            {
                case HttpStatusCode.OK:
                {
                    message = GitHubApiClient.SUCCESSMESSAGE;
                    string content = responce.Content.ReadAsStringAsync().GetAwaiter().GetResult();
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

        /// <summary>
        /// Get list of branch from specified repo.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="repoName">The name of the repository.</param>
        /// <param name="message">The message from client.</param>
        /// <returns>List of branches.</returns>
        public List<Branch> GetBranchesList(string username, string repoName, out string message)
        {
            message = string.Empty;
            string uri = $"{baseUrl}repos/{username}/{repoName}/branches";
            HttpRequestMessage request = this.GenerateBasicRequest(uri);
            HttpResponseMessage responce = this.SendRequest(request);
            switch (responce.StatusCode)
            {
                case HttpStatusCode.OK:
                {
                    message = GitHubApiClient.SUCCESSMESSAGE;
                    string content = responce.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    List<Branch> branches = JsonConvert.DeserializeObject<List<Branch>>(content);
                    return branches;
                }

                case HttpStatusCode.NotFound:
                {
                    message = $"Repo {repoName} or user {username} does not exists";
                    return null;
                }

                default:
                {
                    message = $"Request ended with status code: {responce.StatusCode}";
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets commits from branch.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="repoName">The name of the repository.</param>
        /// <param name="branchName">The name of the branch.</param>
        /// <param name="message">The message from the client.</param>
        /// <returns>List of commits.</returns>
        public List<Commit> GetBranchCommits(string username, string repoName, string branchName, out string message)
        {
            message = string.Empty;
            string uri = $"{baseUrl}repos/{username}/{repoName}/commits?sha={branchName}";
            HttpRequestMessage request = this.GenerateBasicRequest(uri);
            HttpResponseMessage responce = this.SendRequest(request);
            switch (responce.StatusCode)
            {
                case HttpStatusCode.OK:
                {
                    message = GitHubApiClient.SUCCESSMESSAGE;
                    string content = responce.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    List<Commit> branches = JsonConvert.DeserializeObject<List<Commit>>(content);
                    return branches;
                }

                case HttpStatusCode.NotFound:
                {
                    message = $"Repo {repoName} or user {username} or branch {branchName} does not exists";
                    return null;
                }

                default:
                {
                    message = $"Request ended with status code: {responce.StatusCode}";
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets commits from repository.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="repoName">The name of the repository.</param>
        /// <param name="message">The message from the client.</param>
        /// <returns>List of the commits.</returns>
        public List<Commit> GetReposiroryCommits(string username, string repoName, out string message)
        {
            message = string.Empty;
            string uri = $"{baseUrl}repos/{username}/{repoName}/commits";
            HttpRequestMessage request = this.GenerateBasicRequest(uri);
            HttpResponseMessage responce = this.SendRequest(request);
            switch (responce.StatusCode)
            {
                case HttpStatusCode.OK:
                {
                    message = GitHubApiClient.SUCCESSMESSAGE;
                    string content = responce.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    List<Commit> commits = JsonConvert.DeserializeObject<List<Commit>>(content);
                    return commits;
                }
                
                // If Status code is 409 it means that repository is empty.
                case HttpStatusCode.Conflict:
                {
                    message = GitHubApiClient.SUCCESSMESSAGE;
                    return new List<Commit>();
                }

                case HttpStatusCode.NotFound:
                {
                    message = $"Repo {repoName} or user {username} does not exists";
                    return null;
                }

                default:
                {
                    message = $"Request ended with status code: {responce.StatusCode}";
                    return null;
                }
            }
        }

        /// <summary>
        /// Generates basic HttpRequestMessage object.
        /// </summary>
        /// <param name="uri">The uri of the endpoint.</param>
        /// <returns>The basic request object without content.</returns>
        private HttpRequestMessage GenerateBasicRequest(string uri)
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
        private HttpResponseMessage SendRequest(HttpRequestMessage request)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responce = client.SendAsync(request).GetAwaiter().GetResult();
            return responce;
        }
    }
}
