using Colours.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace PracticalProjectTesting.Tests
{
    public class ColoursUtilityTest
    {
        [Fact]
        public void ColourTest()
        {
            //Arrange
            ColoursController testColour = new ColoursController();


            //// Act
            var testColourController = testColour.Get();

           // Assert
            Assert.NotNull(testColourController);
           // Assert.IsType<ActionResult<string>>(testColourController);
        }
    }
}
