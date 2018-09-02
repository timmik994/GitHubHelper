namespace GitHubClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using GitHubClient.Interfaces;

    /// <summary>
    /// Sender of http requests to gitHub api endpoints.
    /// </summary>
    public class HttpRequestSender : IRequestSender
    {
        /// <summary>
        /// Url of basic gitHub endpoint.
        /// </summary>
        public const string BasicEndpoint = "https://api.github.com";

        /// <summary>
        /// Url of graphQl gitHub endpoint.
        /// </summary>
        public const string GraphQlEndpoint = "https://api.github.com/graphql";

        /// <summary>
        /// Name of user agent header.
        /// </summary>
        public const string UserAgentHeaderName = "User-Agent";

        /// <summary>
        /// Access token from gitHub.
        /// </summary>
        private string accessToken;

        /// <summary>
        /// The user agent header value.
        /// </summary>
        private string userAgent;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestSender" /> class.
        /// </summary>
        /// <param name="accessToken">Access token from gitHub.</param>
        /// <param name="userAgent">The user agent header value.</param>
        public HttpRequestSender(string accessToken, string userAgent = "c#App")
        {
            this.accessToken = accessToken;
            this.userAgent = userAgent;
        }

        /// <summary>
        /// Sends GET request to gitHub api.
        /// </summary>
        /// <param name="url">The relative url.</param>
        /// <returns>Responce message.</returns>
        public async Task<HttpResponseMessage> SendGetRequestAsync(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);
            request.Headers.Add("User-Agent", "c#App");
            request.Method = HttpMethod.Get;
            var fullUrl = $"{HttpRequestSender.BasicEndpoint}{url}";
            request.RequestUri = new Uri(fullUrl);
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage responce = await httpClient.SendAsync(request);
                return responce;
            }
        }

        /// <summary>
        /// Sends POST request to gitHub api.
        /// </summary>
        /// <param name="url">The relative url.</param>
        /// <param name="content">The content to send in gitHub.</param>
        /// <returns>Responce message.</returns>
        public async Task<HttpResponseMessage> SendPostRequest(string url, string content)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);
            request.Headers.Add("User-Agent", "c#App");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            var fullUrl = $"{HttpRequestSender.BasicEndpoint}{url}";
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage responce = await httpClient.SendAsync(request);
                return responce;
            }
        }

        /// <summary>
        /// Sends request to gitHub api graohQl endpoint.
        /// </summary>
        /// <param name="graphQlRequest">The graphQl request.</param>
        /// <returns>Responce message.</returns>
        public async Task<HttpResponseMessage> SendRequestToGraphQl(string graphQlRequest)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);
            request.Headers.Add("User-Agent", "c#App");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(graphQlRequest, Encoding.UTF8);
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage responce = await httpClient.SendAsync(request);
                return responce;
            }
        }
    }
}
