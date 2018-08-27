namespace GitHubHelper.Tests
{
    using GitHubHelper.Commands;
    using Xunit;

    /// <summary>
    /// Tests for CommandFactoryClass
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

        /// <summary>
        /// This test tests the creation of command process.
        /// </summary>
        [Fact]
        public void TestGetCommand()
        {
            AbstractCommand commandInstance = CommandFactory.GetCommand("create");
            Assert.IsType<CreateRepoCommand>(commandInstance);
            commandInstance = CommandFactory.GetCommand("unusedword");
            Assert.Null(commandInstance);
        }
    }
}
