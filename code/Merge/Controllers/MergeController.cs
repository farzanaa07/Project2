using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Merge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MergeController : ControllerBase
    {
        public MergeController(IOptions<AppSettings> settings)
        {
            Configuration = settings.Value;
        }
        private AppSettings Configuration;
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
             var numbersService = $"{Configuration.numbersServiceURL}/numbers"; //this is configuration code tha
             var numbersResponseCall = await new HttpClient().GetStringAsync(numbersService);
            var coloursService = $"{Configuration.coloursServiceURL}/colours";
            var coloursResponseCall = await new HttpClient().GetStringAsync(coloursService);

            //IMPLEMENTATION 1
            //if you get colour red and number 2, this will generate 100 prize
            if ((coloursResponseCall == "red" && numbersResponseCall == "1") || (numbersResponseCall == "2") && (coloursResponseCall == "red"))

            {
                var Prize = "£100";
                var mergedResponse = $"Your number is {numbersResponseCall} and colour is {coloursResponseCall}. Your prize is {Prize}";
                return Ok(mergedResponse);
            }


            //if you get colour blue and number 3 or number 4, this will generate 200 prize
            else if ((coloursResponseCall == "blue" && numbersResponseCall == "3") || (coloursResponseCall == "blue" && numbersResponseCall == "4"))

            {
                var Prize = "£200";
                var mergedResponse = $"Your number is {numbersResponseCall} and colour is {coloursResponseCall}. Your prize is {Prize}";
                return Ok(mergedResponse);
            }


            //if you get colour green and number 5 or number 1, this will generate 300 prize
            else if ((coloursResponseCall == "green" && numbersResponseCall == "5") || (numbersResponseCall == "1") && (coloursResponseCall == "green"))
            {
                var Prize = "£300";
                var mergedResponse = $"Your number is {numbersResponseCall} and colour is {coloursResponseCall}. Ypur prize is {Prize}";
                return Ok(mergedResponse);
            }

            //if you get colour purple and number 2 or number 4, this will generate 400 prize
            else if ((coloursResponseCall == "purple" && numbersResponseCall == "2") || (numbersResponseCall == "4") && (coloursResponseCall == "purple"))

            {
                var Prize = "£400";
                var mergedResponse = $"Your number is {numbersResponseCall} and colour is {coloursResponseCall}. Your prize is {Prize}";
                return Ok(mergedResponse);
            }
            else
            {
                var mergedResponse = $"Your number is {numbersResponseCall} and colour is {coloursResponseCall}. You have won nothing. Too bad!";
                return Ok(mergedResponse);
            }


        }
    }
}
