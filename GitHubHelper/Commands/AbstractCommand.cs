namespace GitHubHelper.Commands
{
    using System;

    /// <summary>
    /// Abstract class of the command.
    /// </summary>
    public abstract class AbstractCommand
    {
        /// <summary>
        /// String of yes answer.
        /// </summary>
        private const string YES = "yes";

        /// <summary>
        /// String of no answer.
        /// </summary>
        private const string NO = "no";

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

        /// <summary>
        /// Get useranswer yes or no.
        /// </summary>
        /// <returns>True if user agree. Otherwise false.</returns>
        protected bool GetUserAgree()
        {
            do
            {
                Console.WriteLine("Print [yes/no]");
                string answer = Console.ReadLine();
                if (answer == AbstractCommand.YES)
                {
                    return true;
                }
                else if (answer == AbstractCommand.NO)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Incorrect answer. Print 'yes' or 'no'");
                }
            }
            while (true);
        }
    }
}
