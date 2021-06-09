﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Colours.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColoursController : ControllerBase
    {
        private static readonly string[] Colours = new[]
        {
            "red", "blue", "green", "purple", "yellow", "orange", "pink"
        };

        [HttpGet]
        public string Get()
        {
            var rnd = new Random();
            var returnIndex = rnd.Next(0, 7);
            return Colours[returnIndex].ToString();
        }
    }
}
