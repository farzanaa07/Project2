using Merge;
using Merge.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit;
using RichardSzalay.MockHttp;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace PracticalProjectTesting.Tests
{
    public class MergeControllerTest
    {
    //    private IConfiguration Configuration;
    //    private MergeController mergeController;
    //    public MergeControllerTest() //arguments for merge controller
    //    {
    //    }

    //    [Fact]
    //    public async void mergetest()
    //    {
    //        //arange
    //        var mockHttp = new MockHttpMessageHandler();
    //        mockHttp.When("https://localhost:44307")//this shows mocking - when you go to numbers local host url, you want response of value  "2"
    //            .Respond("text/plain", "1"); //text/plain shows content type
    //        mockHttp.When("https://localhost:44364") //this shows mocking - when you go to colours local host url, you want response of "red"
    //            .Respond("text/plain", "red");
    //        var client = new HttpClient(mockHttp); //initalising http client - this is what the object is making the request and passing in the mock responses as a parameter so you get the values you want
    //        mergeController = new MergeController(client, Configuration);

    //        //Act
    //        var mergedresponse = await mergeController.Get(); // run an await to return the merged response 
    //        var result = (string)((OkObjectResult)mergedresponse).Value;

    //        //Assert
    //        Assert.Equal("Your number is 1 and colour is red. Your prize is £100", result);
    //    }
    }
}

