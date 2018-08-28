namespace GitHubHelper.Commands
{
    using System.Text;

    /// <summary>
    /// Realisation of command pattern.
    /// </summary>
    public static class CommandFactory
    {
        /// <summary>
        /// Create repository command.
        /// </summary>
        public const string CREATE_CMD = "create";

        /// <summary>
        /// Command to get repositories list from other user.
        /// </summary>
        public const string GET_USER_REPOS = "userepos";

        /// <summary>
        /// Command to get list of my repositories.
        /// </summary>
        public const string GET_MY_REPOS = "myrepos";

        /// <summary>
        /// Command to get list of branches.
        /// </summary>
        public const string GET_BRANCHES = "branches";

        /// <summary>
        /// Command to get list of commits in branch.
        /// </summary>
        public const string GET_COMMITS_FROM_BRANCH = "commits";

        /// <summary>
        /// Command to get count of commits.
        /// </summary>
        public const string GET_COMMITS_COUNT = "commitcount";

        /// <summary>
        /// Command to show help.
        /// </summary>
        public const string GET_HELP = "help";

        /// <summary>
        /// Command to exit from application.
        /// </summary>
        public const string EXIT = "exit";

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
                case CommandFactory.CREATE_CMD: return new CreateRepoCommand();
                case CommandFactory.GET_USER_REPOS: return new UserReposCommand();
                case CommandFactory.GET_MY_REPOS: return new MyReposCommand();
                case CommandFactory.GET_BRANCHES: return new GetBranchesCommand();
                case CommandFactory.GET_COMMITS_FROM_BRANCH: return new BranchCommitsCommand();
                case CommandFactory.GET_COMMITS_COUNT: return new CommitCountCommand();
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
            helpMessage.AppendLine($"{CommandFactory.GET_HELP}: show help message.");
            helpMessage.AppendLine($"{CommandFactory.CREATE_CMD}: creates the repository.");
            helpMessage.AppendLine($"{CommandFactory.GET_USER_REPOS}: gets repos for cpecified user.");
            helpMessage.AppendLine($"{CommandFactory.GET_MY_REPOS}: get repositories of current user.");
            helpMessage.AppendLine($"{CommandFactory.GET_BRANCHES}: get list of branches.");
            helpMessage.AppendLine($"{CommandFactory.GET_COMMITS_FROM_BRANCH}: get list of commit in branch.");
            helpMessage.AppendLine($"{CommandFactory.GET_COMMITS_COUNT}: get count of commits.");
            helpMessage.AppendLine("exit: exit from application.");
            return helpMessage.ToString();
        }
    }
}
