namespace GitHubHelper.Commands
{
    /// <summary>
    /// Abstract class of the command.
    /// </summary>
    public abstract class AbstractCommand
    {
        /// <summary>
        /// In this methods command will ack parameters.
        /// </summary>
        public abstract void GetParameters();

        /// <summary>
        /// In this method Actions for command will be processed.
        /// </summary>
        public abstract void RunCommand();

        /// <summary>
        /// In this method results of command will be shown in console.
        /// </summary>
        public abstract void ShowResult();
    }
}
