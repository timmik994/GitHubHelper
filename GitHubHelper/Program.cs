namespace GitHubHelper
{
    using System;
    using GitHubClient;
    using GitHubHelper.Commands;

    /// <summary>
    /// Entry point of the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Const string to write between commands.
        /// </summary>
        public const string DelimeterMessage = "-----------------------------------------------------";

        /// <summary>
        /// Indicates is program need continue running.
        /// </summary>
        private static bool continueRunning;

        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">String of arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine(CommandFactory.GetHelp());
            Console.WriteLine(Program.DelimeterMessage);
            Console.WriteLine("Please enter access token");
            string token = Console.ReadLine();
            GitHubApiClient gitHubClient = GitHubApiClient.GetInstance();
            gitHubClient.SetAccessToken(token);
            continueRunning = true;
            while (continueRunning)
            {
                Console.WriteLine(Program.DelimeterMessage);
                Console.Write(">>>");
                string command = Console.ReadLine();
                ProcessCommand(command);
            }
        }

        /// <summary>
        /// Processes the command.
        /// </summary>
        /// <param name="command">The command from user.</param>
        public static void ProcessCommand(string command)
        {
            if (command == CommandFactory.EXIT)
            {
                Program.continueRunning = false;
                return;
            }

            if (command == CommandFactory.GET_HELP)
            {
                Console.WriteLine(Program.DelimeterMessage);
                Console.WriteLine(CommandFactory.GetHelp());
                return;
            }

            AbstractCommand commandInstance = CommandFactory.GetCommand(command);
            if (commandInstance != null)
            {
                commandInstance.GetParameters();
                commandInstance.RunCommand();
                commandInstance.ShowResult();
            }
            else
            {
                Console.WriteLine($"Command '{command}' is invalid. Please see help.");
                Console.WriteLine(CommandFactory.GetHelp());
            }
        }
    }
}
