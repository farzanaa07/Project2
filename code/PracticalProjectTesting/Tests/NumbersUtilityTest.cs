using Microsoft.AspNetCore.Mvc;
using Numbers.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PracticalProjectTesting.Tests
{
    public class NumbersUtilityTest
    {
        [Fact]
        public void NumbersTest()
        {
            //Arrange
            NumbersController testNumber = new NumbersController();


            //// Act
            var testNumberController = testNumber.Get();

            // Assert
            Assert.NotNull(testNumberController);
            //Assert.IsType<ActionResult<string>>(testNumberController);
        }
    }
}
