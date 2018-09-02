namespace GitHubClient
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;
    using Newtonsoft.Json;

    /// <summary>
    /// Service that works with users.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Owner of accesss token 
        /// </summary>
        private FullUserData currentUser;

        /// <summary>
        /// Instance of requsetSender to send requsets to gitHub api.
        /// </summary>
        private IRequestSender requestSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService" /> class.
        /// </summary>
        /// <param name="requestSender">The IRequestSender instance.</param>
        public UserService(IRequestSender requestSender)
        {
            this.requestSender = requestSender;
        }

        /// <summary>
        /// Gets user who is owner of access token.
        /// </summary>
        /// <returns>ClientResponce instance with full data of current user.</returns>
        public async Task<ClientResponce<FullUserData>> GetCurrentUser()
        {
            if (currentUser != null)
            {
                var userDataResponce = new ClientResponce<FullUserData>()
                {
                    Message = MessagesHelper.DataAlreadyLoadedMessage,
                    ResponceData = this.currentUser,
                    Status = OperationStatus.Susseess
                };
                return userDataResponce;
            }
            else
            {
                var url = $"/{UrlConstants.currentUserUrlPart}";
                HttpResponseMessage httpResponce = await this.requestSender.SendGetRequestAsync(url);
                var clientRessponce = new ClientResponce<FullUserData>();
                switch (httpResponce.StatusCode)
                {
                    case HttpStatusCode.OK:
                        string userJson = httpResponce.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        this.currentUser = JsonConvert.DeserializeObject<FullUserData>(userJson);
                        clientRessponce.ResponceData = this.currentUser;
                        clientRessponce.Status = OperationStatus.Susseess;
                        clientRessponce.Message = MessagesHelper.StandartSuccessMessage;
                        break;
                    case HttpStatusCode.Unauthorized:
                        clientRessponce.Message = MessagesHelper.UnAuthorizedMessage;
                        clientRessponce.Status = OperationStatus.Error;
                        break;
                    default:
                        clientRessponce.Message = MessagesHelper.UnknownErrorMessage;
                        clientRessponce.Status = OperationStatus.UnknownState;
                        break;
                }

                return clientRessponce;
            }
        }

        /// <summary>
        /// Gets full data of specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>ClientResponce instance with full data of current user.</returns>
        public async Task<ClientResponce<FullUserData>> GetFullUserData(string username)
        {
            var url = $"/{UrlConstants.UsersUrlPart}/{username}";
            HttpResponseMessage httpResponce = await this.requestSender.SendGetRequestAsync(url);
            var clientRessponce = new ClientResponce<FullUserData>();
            switch (httpResponce.StatusCode)
            {
                case HttpStatusCode.OK:
                    string userJson = httpResponce.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    this.currentUser = JsonConvert.DeserializeObject<FullUserData>(userJson);
                    clientRessponce.ResponceData = this.currentUser;
                    clientRessponce.Status = OperationStatus.Susseess;
                    clientRessponce.Message = MessagesHelper.StandartSuccessMessage;
                    break;
                case HttpStatusCode.NotFound:
                    clientRessponce.Message = MessagesHelper.GenerateUserNotFoundMessage(username);
                    clientRessponce.Status = OperationStatus.NotFound;
                    break;
                case HttpStatusCode.Unauthorized:
                    clientRessponce.Message = MessagesHelper.UnAuthorizedMessage;
                    clientRessponce.Status = OperationStatus.Error;
                    break;
                default:
                    clientRessponce.Message = MessagesHelper.UnknownErrorMessage;
                    clientRessponce.Status = OperationStatus.UnknownState;
                    break;
            }

            return clientRessponce;
        }

        /// <summary>
        /// Gets full data of specified user.
        /// </summary>
        /// <param name="userData">The BasicUserData object.</param>
        /// <returns>ClientResponce instance with full data of current user.</returns>
        public async Task<ClientResponce<FullUserData>> GetFullUserData(BasicUserData userData)
        {
            if (userData != null)
            {
                return await this.GetFullUserData(userData.Login);
            }
            else
            {
                var clientResponce = new ClientResponce<FullUserData>()
                {
                    Message = MessagesHelper.EmptyDataMessage,
                    Status = OperationStatus.InvalidData
                };
                return clientResponce;
            }
            
        }

    }
}
