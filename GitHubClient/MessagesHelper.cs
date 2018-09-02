using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubClient
{
    /// <summary>
    /// Message helper class.
    /// </summary>
    public static class MessagesHelper
    {
        /// <summary>
        /// Message if operation successfull
        /// </summary>
        public const string StandartSuccessMessage = "Operation end with success";

        /// <summary>
        /// Message is data loaded from local source.
        /// </summary>
        public const string DataAlreadyLoadedMessage = "Data already loaded from gitHub";

        /// <summary>
        /// Message if unauthorized status code.
        /// </summary>
        public const string UnAuthorizedMessage = "Invalid access token.";

        /// <summary>
        /// Message if unknown error.
        /// </summary>
        public const string UnknownErrorMessage = "Operation ended with unknown error";

        /// <summary>
        /// Message if object is null or has empty field.
        /// </summary>
        public const string EmptyDataMessage = "Data object is null.";

        /// <summary>
        /// Mesage if user not found.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GenerateUserNotFoundMessage(string username)
        {
            return $"User {username} Not found";
        }
    }
}
