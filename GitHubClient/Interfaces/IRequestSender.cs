namespace GitHubClient.Interfaces
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Methods to send request to gitHub.
    /// </summary>
    public interface IRequestSender
    {
        /// <summary>
        /// Sends GET request to basic git hub api endpoint.
        /// </summary>
        /// <param name="url">The relative url.</param>
        /// <returns>Http response message.</returns>
        Task<HttpResponseMessage> SendGetRequestAsync(string url);

        /// <summary>
        /// Sends POST request to basic git hub api endpoint.
        /// </summary>
        /// <param name="url">The relative url.</param>
        /// <param name="content">Content to send in request.</param>
        /// <returns>Http response message.</returns>
        Task<HttpResponseMessage> SendPostRequest(string url, string content);

        /// <summary>
        /// Send request to GraphQl gitHub api endpoint.
        /// </summary>
        /// <param name="graphQlRequest">GraphQl request.</param>
        /// <returns>Http response message.</returns>
        Task<HttpResponseMessage> SendRequestToGraphQl(string graphQlRequest);
    }
}
