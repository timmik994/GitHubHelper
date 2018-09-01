namespace GitHubClient.Interfaces
{
    using System.Net.Http;

    /// <summary>
    /// Methods to send request to gitHub.
    /// </summary>
    public interface IRequestSender
    {
        /// <summary>
        /// Sends GET request to basic git hub api endpoint.
        /// </summary>
        /// <param name="url">The relative url.</param>
        /// <returns>Response message.</returns>
        HttpResponseMessage SendGetRequest(string url);

        /// <summary>
        /// Sends POST request to basic git hub api endpoint.
        /// </summary>
        /// <param name="url">The relative url.</param>
        /// <param name="comtent">Content to send in request.</param>
        /// <returns>Response message.</returns>
        HttpResponseMessage SendPostRequest(string url, string comtent);

        /// <summary>
        /// Send request to GraphQl gitHub api endpoint.
        /// </summary>
        /// <param name="graphQlRequest">GraphQl request.</param>
        /// <returns>Response message.</returns>
        HttpResponseMessage SendRequestToGraphQl(string graphQlRequest);
    }
}
