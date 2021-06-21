using FrontEnd;
using FrontEnd.Controllers;
using FrontEnd.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using PracticalProjectTesting.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace PracticalProjectTesting.Tests
{
    public class FrontendTest
    {
        private Mock<IUserInput> userInputMock;
        private Mock<IRepositoryWrapper> mockRepo;
        private HomeController homeController;
        private AddUserBindingModel addUserInput;
        private UserInput userInput;
        private readonly ILogger<HomeController> _logger;
        private AppSettings appSettings = new AppSettings()
        {
            mergedServiceURL = "https://farzana-app-service.azurewebsites.net/"
        };
        public FrontendTest()
        {
            //mocksetup
            userInputMock = new Mock<IUserInput>();
            userInput = new UserInput();

            //sample models
            addUserInput = new AddUserBindingModel { FirstName = "Harry", LastName = "Smith" };

            //controller setup

            mockRepo = new Mock<IRepositoryWrapper>();

        }


        [Fact]
        public void UserInputTest()
        {
            //Arrange
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            mockRepo.Setup(repo => repo.UserInput.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetUserInput());

            //Act
            homeController = new HomeController(_logger, options.Object, mockRepo.Object);

            var controllerActionResult = homeController.Index(addUserInput);

            //Assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<RedirectToActionResult>(controllerActionResult);
        }
        [Fact]
        public async void GetFrontEndTest()
        {


            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);

            HomeController homeController = new HomeController( _logger,options.Object,mockRepo.Object);
            var homeContollerResult = await homeController.Merge();

            Assert.NotNull(homeContollerResult);
           //ssert.IsType<OkObjectResult>(homeContollerResult);


        }

        private IEnumerable<UserInput>GetUserInput()
        {
            var userInputs = new List<UserInput>
            {new UserInput() { ID = 1, FirstName = "Harry", LastName = "Smith"} };
        return userInputs;
    }


    }
}

