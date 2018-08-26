namespace GitHubHelper.Tests
{
    using Xunit;

    /// <summary>
    /// Tests for the methods in Program class.
    /// </summary>
    public class ProgramTest
    {
        /// <summary>
        /// This test tests ProcessCommand Method.
        /// </summary>
        [Fact]
        public void TestProcessCommand()
        {
            bool result = Program.ProcessCommand("exit");
            Assert.False(result);
            result = Program.ProcessCommand("help");
            Assert.True(result);
        }
    }
}
