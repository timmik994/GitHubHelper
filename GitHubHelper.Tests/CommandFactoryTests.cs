namespace GitHubHelper.Tests
{
    using GitHubHelper.Commands;
    using Xunit;

    /// <summary>
    /// This class contains tests for CommandFactoryClass
    /// </summary>
    public class CommandFactoryTests
    {
        /// <summary>
        /// This test tests help message.
        /// </summary>
        [Fact]
        public void TestGetHelp()
        {
            string helpString = CommandFactory.GetHelp();
            Assert.NotEmpty(helpString);
            Assert.StartsWith("help", helpString);
        }
    }
}
