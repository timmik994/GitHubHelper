﻿namespace GitHubClient.DataServices
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;
    using Newtonsoft.Json;

    /// <summary>
    /// Service that works with branch data.
    /// </summary>
    public class BranchService : IBranchService
    {
        /// <summary>
        /// Instance of requsetSender to send requsets to gitHub api.
        /// </summary>
        private IRequestSender requestSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchService" /> class.
        /// </summary>
        /// <param name="requestSender">The IRequestSender instance.</param>
        public BranchService(IRequestSender requestSender)
        {
            this.requestSender = requestSender;
        }

        /// <summary>
        /// Gets branches list of specified repository.
        /// </summary>
        /// <param name="username">The name of repository owner.</param>
        /// <param name="repositoryName">The repository name.</param>
        /// <returns>ClientResponse instance with collection of branches.</returns>
        public async Task<ClientResponse<IEnumerable<Branch>>> GetBranchList(string username, string repositoryName)
        {
            if (username == string.Empty || repositoryName == string.Empty)
            {
                var clientResponse = new ClientResponse<IEnumerable<Branch>>
                {
                    Message = MessagesHelper.EmptyDataMessage,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            var url = $"/{UrlConstants.RepositoriesUrlPart}/{username}/{repositoryName}/{UrlConstants.BranchesUrlPart}";
            HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
            return await this.requestSender.ProcessHttpResponse<IEnumerable<Branch>>(
                httpResponse, 
                MessagesHelper.GenerateUserOrRepositoryNotFoundMessage(username, repositoryName));
        }

        /// <summary>
        /// Gets branches list of specified repository.
        /// </summary>
        /// <param name="repositoryData">The data of repository.</param>
        /// <returns>ClientResponse instance with collection of branches.</returns>
        public async Task<ClientResponse<IEnumerable<Branch>>> GetBranchList(BasicRepositoryData repositoryData)
        {
            if (repositoryData == null)
            {
                var clientResponse = new ClientResponse<IEnumerable<Branch>>
                {
                    Message = MessagesHelper.EmptyDataMessage,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            return await this.GetBranchList(repositoryData.Owner.Login, repositoryData.Name);
        }
    }
}
