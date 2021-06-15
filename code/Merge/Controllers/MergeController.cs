using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Merge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MergeController : ControllerBase
    {
        ///numbersURL: https://localhost:44307/
        ///coloursURL:https://localhost:44364/
        ///
        private static readonly string[] Prize = new[]
       {
            "£100", "£200", "£300", "£400", "£500"
        };

        private IConfiguration Configuration; //inject values inside classes by using depedency injection
        public MergeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var numbersService = $"{Configuration["numbersServiceURL"]}/numbers"; //this is configuration code tha
            var numbersResponseCall = await new HttpClient().GetStringAsync(numbersService);
            var coloursService = $"{Configuration["coloursServiceURL"]}/colours";
            var coloursResponseCall = await new HttpClient().GetStringAsync(coloursService);


            //if you get colour red and number 2, this will generate 100 prize
            if (coloursResponseCall == "red" && numbersResponseCall == "1")

            {
                var Prize = "£100";
                var mergedResponse = $"Your number is {numbersResponseCall} and colour is {coloursResponseCall}. This means your prize is of {Prize}";
                return Ok(mergedResponse);
            }


            //if you get colour blue and number 2, this will generate 200 prize
            else if (coloursResponseCall == "blue" && numbersResponseCall == "2")

            {
                var Prize = "£200";
                var mergedResponse = $"Your number is {numbersResponseCall} and colour is {coloursResponseCall}. This means your prize is of {Prize}";
                return Ok(mergedResponse);
            }


            //if you get colour green and number 3, this will generate 300 prize
            else if (coloursResponseCall == "green" && numbersResponseCall == "3")

            {
                var Prize = "£300";
                var mergedResponse = $"Your number is {numbersResponseCall} and colour is {coloursResponseCall}. This means your prize is of {Prize}";
                return Ok(mergedResponse);
            }

            //if you get colour purple and number 4, this will generate 400 prize
            else if (coloursResponseCall == "purple" && numbersResponseCall == "4")

            {
                var Prize = "£400";
                var mergedResponse = $"Your number is {numbersResponseCall} and colour is {coloursResponseCall}. This means your prize is of {Prize}";
                return Ok(mergedResponse);
            }
            else
            {
                var mergedResponse = $"Your number is {numbersResponseCall} and colour is {coloursResponseCall}. This means you won no prize";
             return Ok(mergedResponse); }


        }
        }
}
