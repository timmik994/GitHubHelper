

namespace GitHubHelper
{
    using System;
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
            Console.WriteLine("Please enter access token");
            string token = Console.ReadLine();
        }

    }
}
