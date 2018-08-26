namespace GitHubClient.Tests
{
    using System.Net.Http;
    using GitHubClient;
    using Xunit;

    /// <summary>
    /// This class contains tests for test git hub api client.
    /// </summary>
    public class GitHubApiClientTests
    {
        /// <summary>
        /// This test checks initialization of GitHubApiClient class.
        /// </summary>
        [Fact]
        public void TestInitialization()
        {
            GitHubApiClient testClient = GitHubApiClient.GetInstance();
            Assert.NotNull(testClient);
        }

        /// <summary>
        /// Tests is GitHubApiClient is singleton.
        /// </summary>
        [Fact]
        public void TestSingleton()
        {
            GitHubApiClient client1 = GitHubApiClient.GetInstance();
            GitHubApiClient client2 = GitHubApiClient.GetInstance();
            Assert.Equal(client1, client2);
        }

        /// <summary>
        /// This test tests generation of basic HttpRequestMessage object.
        /// </summary>
        [Fact]
        public void TestGenerateBasicRequest()
        {
            GitHubApiClient testClient = GitHubApiClient.GetInstance();
            string testURI = "https://api.github.com/repos";
            HttpRequestMessage testRequest = testClient.GenerateBasicRequest(testURI);
            Assert.NotNull(testRequest);
            Assert.NotNull(testRequest.Headers.Authorization);
            Assert.NotNull(testRequest.Headers.UserAgent);
            Assert.Equal(testURI, testRequest.RequestUri.ToString());
        }
    }
}
