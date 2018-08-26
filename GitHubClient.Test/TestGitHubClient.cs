using GitHubClient;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GitHubClient.Tests
{
    public class GitHubApiClientTests
    {
        /// <summary>
        /// This test checks initialization of GitHubApiClient class.
        /// </summary>
        [Fact]
        public void TestInitialization()
        {
            GitHubApiClient testClient=GitHubApiClient.GetInstance();
            Assert.NotNull(testClient);
        }

        /// <summary>
        /// Tests is GitHubApiClient is singleton.
        /// </summary>
        [Fact]
        public void TestSingleton()
        {
            GitHubApiClient client1=GitHubApiClient.GetInstance();
            GitHubApiClient client2=GitHubApiClient.GetInstance();
            Assert.Equal(client1, client2);
        }

    }
}
