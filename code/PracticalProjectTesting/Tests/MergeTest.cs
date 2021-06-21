using Merge;
using Merge.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit;
using RichardSzalay.MockHttp;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Moq;

namespace PracticalProjectTesting.Tests
{
    public class MergeTest
    {

        private AppSettings appSettings = new AppSettings()
        {
            numbersServiceURL = "https://farzana-numbers.azurewebsites.net",
            coloursServiceURL = "http://farzana-colour.azurewebsites.net"
        };
        [Fact]
        public async void GetTest()
        {
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);

            MergeController mergeController = new MergeController(options.Object);
            var mergeContollerResult = await mergeController.Get();

            Assert.NotNull(mergeContollerResult);
            Assert.IsType<OkObjectResult>(mergeContollerResult);
        }
    }
}