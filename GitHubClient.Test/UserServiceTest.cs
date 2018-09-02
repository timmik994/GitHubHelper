namespace GitHubClient.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;
    using Moq;
    using Newtonsoft.Json;
    using Xunit;

    /// <summary>
    /// Unit tests for userService class.
    /// </summary>
    public class UserServiceTest
    {
        /// <summary>
        /// Test user login.
        /// </summary>
        private const string TestUserLogin = "test";

        /// <summary>
        /// Test return value in successfull operation.
        /// </summary>
        [Fact]
        public void TestGetCurrentUserFirstTime()
        {
            var mock = new Mock<IRequestSender>();
            HttpResponseMessage testResponce = this.GenerateSussessfulResponceMessage();
            mock.Setup(sender => sender.SendGetRequestAsync($"/{UrlConstants.currentUserUrlPart}"))
                .ReturnsAsync(testResponce);
            UserService userService = new UserService(mock.Object);
            ClientResponce<FullUserData> testClientResponce = userService.GetCurrentUser().GetAwaiter().GetResult();
            Assert.Equal(OperationStatus.Susseess, testClientResponce.Status);
            Assert.Equal(MessagesHelper.StandartSuccessMessage, testClientResponce.Message);
            FullUserData loadedUser = testClientResponce.ResponceData;
            Assert.Equal(UserServiceTest.TestUserLogin, TestUserLogin);
        }

        /// <summary>
        /// Testa that insecond request returns same user object as in first.
        /// </summary>
        [Fact]
        public void TestGetCurrentUserSecondTime()
        {
            var mock = new Mock<IRequestSender>();
            HttpResponseMessage testResponce = this.GenerateSussessfulResponceMessage();
            mock.Setup(sender => sender.SendGetRequestAsync($"/{UrlConstants.currentUserUrlPart}"))
                .ReturnsAsync(testResponce);
            UserService userService = new UserService(mock.Object);
            ClientResponce<FullUserData> testClientResponceFirst = userService.GetCurrentUser().GetAwaiter().GetResult();
            ClientResponce<FullUserData> testClientResponceSecond = userService.GetCurrentUser().GetAwaiter().GetResult();
            Assert.Equal(testClientResponceFirst.ResponceData, testClientResponceSecond.ResponceData);
            Assert.Equal(MessagesHelper.DataAlreadyLoadedMessage, testClientResponceSecond.Message);
        }

        /// <summary>
        /// Tests GetCurrentUser if access token is wrong.
        /// </summary>
        [Fact]
        public void TestGetCurrentUserWrongToken()
        {
            var httpResponce = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var mock = new Mock<IRequestSender>();
            mock.Setup(sender => sender.SendGetRequestAsync($"/{UrlConstants.currentUserUrlPart}"))
                .ReturnsAsync(httpResponce);
            UserService userService = new UserService(mock.Object);
            ClientResponce<FullUserData> testClientResponce = userService.GetCurrentUser().GetAwaiter().GetResult();
            Assert.Equal(OperationStatus.Error, testClientResponce.Status);
            Assert.Equal(MessagesHelper.UnAuthorizedMessage, testClientResponce.Message);
            Assert.Null(testClientResponce.ResponceData);
        }

        /// <summary>
        /// Tests situation with unknown error in http request.
        /// </summary>
        [Fact]
        public void TestGetCurrentUserUnknownError()
        {
            var httpResponce = new HttpResponseMessage(HttpStatusCode.BadGateway);
            var mock = new Mock<IRequestSender>();
            mock.Setup(sender => sender.SendGetRequestAsync($"/{UrlConstants.currentUserUrlPart}"))
                .ReturnsAsync(httpResponce);
            UserService userService = new UserService(mock.Object);
            ClientResponce<FullUserData> testClientResponce = userService.GetCurrentUser().GetAwaiter().GetResult();
            Assert.Equal(OperationStatus.UnknownState, testClientResponce.Status);
            Assert.Equal(MessagesHelper.UnknownErrorMessage, testClientResponce.Message);
            Assert.Null(testClientResponce.ResponceData);
        }

        /// <summary>
        /// Tests GetUserData with string param sussess responce.
        /// </summary>
        [Fact]
        public void TestGetUserDataSuccess()
        {
            var mock = new Mock<IRequestSender>();
            HttpResponseMessage testResponce = this.GenerateSussessfulResponceMessage();
            mock.Setup(sender => sender.SendGetRequestAsync($"/{UrlConstants.UsersUrlPart}/{UserServiceTest.TestUserLogin}"))
                .ReturnsAsync(testResponce);
            UserService userService = new UserService(mock.Object);
            ClientResponce<FullUserData> testClientResponce = userService.GetFullUserData(UserServiceTest.TestUserLogin).GetAwaiter().GetResult();
            Assert.Equal(OperationStatus.Susseess, testClientResponce.Status);
            Assert.Equal(MessagesHelper.StandartSuccessMessage, testClientResponce.Message);
            FullUserData loadedUser = testClientResponce.ResponceData;
            Assert.Equal(UserServiceTest.TestUserLogin, TestUserLogin);
        }

        /// <summary>
        /// Tests if user not found.
        /// </summary>
        [Fact]
        public void TestGetUserDataNotFound()
        {
            var httpResponce = new HttpResponseMessage(HttpStatusCode.NotFound);
            var mock = new Mock<IRequestSender>();
            mock.Setup(sender => sender.SendGetRequestAsync($"/{UrlConstants.UsersUrlPart}/{UserServiceTest.TestUserLogin}"))
                .ReturnsAsync(httpResponce);
            UserService userService = new UserService(mock.Object);
            ClientResponce<FullUserData> testClientResponce = userService.GetFullUserData(UserServiceTest.TestUserLogin).GetAwaiter().GetResult();
            Assert.Equal(OperationStatus.NotFound, testClientResponce.Status);
            Assert.Equal(MessagesHelper.GenerateUserNotFoundMessage(UserServiceTest.TestUserLogin), testClientResponce.Message);
            Assert.Null(testClientResponce.ResponceData);
        }

        /// <summary>
        /// Tests GetUserData with object param if object is null.
        /// </summary>
        [Fact]
        public void TestGetUserDataNull()
        {
            var httpResponce = new HttpResponseMessage(HttpStatusCode.NotFound);
            var mock = new Mock<IRequestSender>();
            mock.Setup(sender => sender.SendGetRequestAsync($"/{UrlConstants.UsersUrlPart}/{UserServiceTest.TestUserLogin}"))
                .ReturnsAsync(httpResponce);
            UserService userService = new UserService(mock.Object);
            ClientResponce<FullUserData> testClientResponce = userService.GetFullUserData((BasicUserData)null).GetAwaiter().GetResult();
            Assert.Equal(OperationStatus.InvalidData, testClientResponce.Status);
            Assert.Equal(MessagesHelper.EmptyDataMessage, testClientResponce.Message);
            Assert.Null(testClientResponce.ResponceData);
        }

        /// <summary>
        /// Generates test user object.
        /// </summary>
        /// <returns>Test user object.</returns>
        private FullUserData GenerateTestUser()
        {
            var testUser = new FullUserData()
            {
                Login = UserServiceTest.TestUserLogin,
                Name = "test name",
                CreatedAt = DateTime.Now,
                Email = "testMail",
                Company = "no",
                FolloversCount = 1,
                FollowingCount = 2,
                Location = "russia",
                PublicReposCount = 4,
                URL = "url",
                UpdatedAt = DateTime.Today
            };
            return testUser;
        }

        /// <summary>
        /// Generates json string of user object.
        /// </summary>
        /// <param name="userObj">The user object.</param>
        /// <returns>Json string.</returns>
        private string GenerateUserJson(FullUserData userObj)
        {
            return JsonConvert.SerializeObject(userObj);
        }

        /// <summary>
        /// Generates sussessfui http responce.
        /// </summary>
        /// <returns>Http responce with status Ok.</returns>
        private HttpResponseMessage GenerateSussessfulResponceMessage()
        {
            FullUserData testUser = this.GenerateTestUser();
            string jsonString = this.GenerateUserJson(testUser);
            var respMsg = new HttpResponseMessage(HttpStatusCode.OK);
            respMsg.Content = new StringContent(jsonString);
            return respMsg;
        }
    }
}
