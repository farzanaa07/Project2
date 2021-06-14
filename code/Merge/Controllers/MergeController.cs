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
        private static readonly int[] PrizeGenerator = new[]
       {
            100, 200, 300
        };

       public string GetPrize()
        {
            Random rand = new Random();
            var returnIndex = rand.Next(0, 3);
            return PrizeGenerator[returnIndex].ToString();
        }
        private IConfiguration Configuration; //inject values inside classes by using depedency injection
        public MergeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var numbersService = "https://localhost:44307/numbers";
            var numbersService = $"{Configuration["numbersServiceURL"]}/numbers"; //this is configuration code tha
            var numbersResponseCall = await new HttpClient().GetStringAsync(numbersService);
            //var coloursService = "https://localhost:44364/colours";
            var coloursService = $"{Configuration["coloursServiceURL"]}/colours";
            var coloursResponseCall = await new HttpClient().GetStringAsync(coloursService);
            // var lettersService = $"https://{Configuration["lettersServiceURL"]}/letters";
            var Prize = GetPrize();

            var mergedResponse = $"Your number is {numbersResponseCall} and colour is {coloursResponseCall}. This means your prize is of {Prize}";
            return Ok(mergedResponse);
        }
    }
}
