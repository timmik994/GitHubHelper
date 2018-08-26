namespace GitHubHelper.Commands
{
    using System.Text;

    /// <summary>
    /// This class will create command
    /// instances by command string.
    /// </summary>
    public static class CommandFactory
    {
        /// <summary>
        /// Initializes and returns instance of command
        /// by command string.
        /// </summary>
        /// <param name="command">The command string.</param>
        /// <returns>Instance of the Command.</returns>
        public static AbstractCommand GetCommand(string command)
        {
            switch (command)
            {
                case "create": return new CreateRepoCommand();
                case "getusrrepos": return new UserReposCommand();
                default: return null;
            }
        }

        /// <summary>
        /// This class generates help message to show instruction in the console.
        /// </summary>
        /// <returns>The help message.</returns>
        public static string GetHelp()
        {
            StringBuilder helpMessage = new StringBuilder();
            helpMessage.AppendLine("help: show help message.");
            helpMessage.AppendLine("create: creates the repository");
            helpMessage.AppendLine("getusrrepos: gets repos for cpecified user");
            helpMessage.AppendLine("exit: exit from application.");
            return helpMessage.ToString();
        }
    }
}
