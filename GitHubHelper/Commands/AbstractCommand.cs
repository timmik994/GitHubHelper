namespace GitHubHelper.Commands
{
    /// <summary>
    /// This class contains fields and methods
    /// that common for all commands.
    /// </summary>
    public abstract class AbstractCommand
    {
        /// <summary>
        /// In this methods command will ack user for parameters.
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
