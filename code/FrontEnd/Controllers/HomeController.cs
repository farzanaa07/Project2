using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEnd.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public async Task<IActionResult> Index()  //method
        {
            //var mergedService = $"https://{Configuration["mergeServiceURL"]}/merge";
            var mergedService = "https://localhost:44371/merge";
            var mergeResponseCall = await new HttpClient().GetStringAsync(mergedService);
            ViewBag.responseCall = mergeResponseCall;
            return View();
        }
    }
}
