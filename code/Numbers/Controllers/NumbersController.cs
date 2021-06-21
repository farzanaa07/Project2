using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Numbers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumbersController : ControllerBase
    {
        public int[] Numbers = new[]
         {
            1,2,3,4,5
        };

        [HttpGet]
        public ActionResult<string> Get()
        {
            var rnd = new Random();
            var returnIndex = rnd.Next(0, 4);
            return Numbers[returnIndex].ToString();
        }
    }
}