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
        /// The main method.
        /// </summary>
        /// <param name="args">String of arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine(CommandFactory.GetHelp());
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Please enter access token");
            string token = Console.ReadLine();
            GitHubApiClient gitHubClient = GitHubApiClient.GetInstance();
            gitHubClient.SetAccessToken(token);
            while (true)
            {
                Console.WriteLine("--------------------------", ConsoleColor.DarkYellow);
                string command = Console.ReadLine();

                if (command == "exit")
                {
                    break;
                }

                if (command == "help")
                {
                    Console.WriteLine(CommandFactory.GetHelp());
                    continue;
                }

                AbstractCommand commandInstance = CommandFactory.GetCommand(command);
                commandInstance.GetParameters();
                commandInstance.RunCommand();
                commandInstance.ShowResult();
            }
        }
    }
}
