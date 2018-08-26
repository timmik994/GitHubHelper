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
        private const string DelimeterMessage = "-----------------------------------------------------";

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
            bool running = true;
            while (running)
            {
                Console.WriteLine(Program.DelimeterMessage);
                Console.Write(">>>");
                string command = Console.ReadLine();
                running = ProcessCommand(command);
            }
        }

        /// <summary>
        /// Processes the command.
        /// </summary>
        /// <param name="command">The command from user.</param>
        /// <returns>The false if nedeed to stop application. Otherwise true.</returns>
        public static bool ProcessCommand(string command)
        {
            if (command == "exit")
            {
                return false;
            }

            if (command == "help")
            {
                Console.WriteLine(Program.DelimeterMessage);
                Console.WriteLine(CommandFactory.GetHelp());
                return true;
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

            return true;
        }
    }
}
