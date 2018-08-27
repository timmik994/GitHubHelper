namespace GitHubHelper.Commands
{
    using System.Text;

    /// <summary>
    /// Realisation of command pattern.
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
                case "userepos": return new UserReposCommand();
                case "myrepos": return new MyReposCommand();
                case "branches": return new GetBranchesCommand();
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
            helpMessage.AppendLine("create: creates the repository.");
            helpMessage.AppendLine("userepos: gets repos for cpecified user.");
            helpMessage.AppendLine("myrepos: get repositories of current user.");
            helpMessage.AppendLine("branches: get list of branches");
            helpMessage.AppendLine("exit: exit from application.");
            return helpMessage.ToString();
        }
    }
}
