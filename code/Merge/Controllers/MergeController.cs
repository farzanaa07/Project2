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
           // var shapesService = $"{Configuration["shapesServiceURL"]}/shapes";
           // var shapesResponseCall = await new HttpClient().GetStringAsync(shapesService);
            var coloursService = $"{Configuration["coloursServiceURL"]}/colours";
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


            ////IMPLEMENTATION 2
            ////if you get colour red and number 2, this will generate 100 prize
            //if ((coloursResponseCall == "red" && shapesResponseCall == "https://upload.wikimedia.org/wikipedia/commons/thumb/0/02/Red_Circle%28small%29.svg/1200px-Red_Circle%28small%29.svg.png") || (shapesResponseCall == "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4b/Armed_forces_red_triangle.svg/1200px-Armed_forces_red_triangle.svg.png"))

            //{
            //    var Prize = "£100";
            //    var mergedResponse = $"Your shape is {shapesResponseCall} and colour is {coloursResponseCall}. Your prize is {Prize}";
            //    return Ok(mergedResponse);
            //}


            ////if you get colour blue and number 3 or number 4, this will generate 200 prize
            //else if ((coloursResponseCall == "blue" && shapesResponseCall == "https://img.favpng.com/18/12/25/triangle-blue-shape-png-favpng-GiyVGMhuhVfrT688Zw5x4DGXH.jpg") || (shapesResponseCall == "https://www.nationalflags.shop/WebRoot/vilkasfi01/Shops/2014080403/53F0/F886/BB3A/522C/CB5B/0A28/100A/2578/blue_rectangle.jpg"))

            //{
            //    var Prize = "£200";
            //    var mergedResponse = $"Your shape is {shapesResponseCall} and colour is {coloursResponseCall}. Your prize is {Prize}";
            //    return Ok(mergedResponse);
            //}


            ////if you get colour green and number 3, this will generate 300 prize
            //else if ((coloursResponseCall == "blue" && shapesResponseCall == "3") || (shapesResponseCall == "4"))
            //{
            //    var Prize = "£300";
            //    var mergedResponse = $"Your shape is {shapesResponseCall} and colour is {coloursResponseCall}. Ypur prize is {Prize}";
            //    return Ok(mergedResponse);
            //}

            ////if you get colour purple and number 4, this will generate 400 prize
            //else if ((coloursResponseCall == "blue" && shapesResponseCall == "https://i.imgur.com/OaD3bWV.jpg") || (shapesResponseCall == "https://image.pngaaa.com/575/62575-middle.png"))

            //{
            //    var Prize = "£400";
            //    var mergedResponse = $"Your shape is {shapesResponseCall} and colour is {coloursResponseCall}. Your prize is {Prize}";
            //    return Ok(mergedResponse);
            //}
            //else
            //{
            //    var mergedResponse = $"Your shape is {shapesResponseCall} and colour is {coloursResponseCall}. This means you won no prize";
            //    return Ok(mergedResponse);
            //}


        }
    }
}
