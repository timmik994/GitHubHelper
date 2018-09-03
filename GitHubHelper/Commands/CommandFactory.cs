﻿namespace GitHubHelper.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using GitHubClient;

    /// <summary>
    /// Realisation of command pattern.
    /// </summary>
    public class CommandFactory
    {
        /// <summary>
        /// Typec of commands
        /// </summary>
        private List<Type> commandClasses = new List<Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFactory" /> class.
        /// </summary>
        public CommandFactory()
        {
            List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            foreach (var assembly in assemblies)
            {
                List<Type> comandTypes = assembly.GetTypes().Where(tp => tp.IsSubclassOf(typeof(AbstractCommand))).ToList();
                this.commandClasses.AddRange(comandTypes);
            }
        }

        /// <summary>
        /// Initializes and returns instance of command
        /// by command string.
        /// </summary>
        /// <param name="command">The command string.</param>
        /// <returns>Instance of the Command.</returns>
        public AbstractCommand GetCommand(string command)
        {
            //Type commandType = this.commandClasses.Find(cmdClass => this.IsRightCommand(command, cmdClass));
            //ConsoleWorker consoleHelper = new ConsoleWorker();
            //GitHubApiClient gitHubClient = GitHubApiClient.GetInstance();
            //var constructorArgs = new object[] { consoleHelper, gitHubClient };
            //AbstractCommand commandInstance = Activator.CreateInstance(commandType, constructorArgs) as AbstractCommand;
            //return commandInstance;
            return null;
        }

        /// <summary>
        /// Check if commandClass type is right type of command  for presented string.
        /// </summary>
        /// <param name="command">Command string.</param>
        /// <param name="commandClass">The type for check.</param>
        /// <returns>True if type is right. Otherwise false.</returns>
        private bool IsRightCommand(string command, Type commandClass)
        {
            CommandAttribute commandAttribute = commandClass.GetCustomAttribute(typeof(CommandAttribute)) as CommandAttribute;
            if (commandAttribute == null)
            {
                return false;
            }

            if (commandAttribute.CommandString == command)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
