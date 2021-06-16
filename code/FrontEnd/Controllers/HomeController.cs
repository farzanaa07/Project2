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
using Microsoft.EntityFrameworkCore;


namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ApplicationDbContext dbContext;
        //public HomeController(ApplicationDbContext applicationDbContext)
        //{
        //    dbContext = applicationDbContext;
        //}
    
        private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public async Task<IActionResult> Merge()  //method
        {
            var mergedService = $"{Configuration["mergedServiceURL"]}/merge";
            //var mergedService = "https://localhost:44327/merge";
            var mergeResponseCall = await new HttpClient().GetStringAsync(mergedService);
            ViewBag.responseCall = mergeResponseCall;

            return View();
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("")]
        public IActionResult Index(AddUserBindingModel bindingModel)
        {
            var userToCreate = new UserInput
            {
                FirstName = bindingModel.FirstName,
                LastName = bindingModel.LastName
            };
            //dbContext.UserInput.Add(userToCreate);
            //dbContext.SaveChanges();
            ViewBag.FirstName = userToCreate.FirstName;
            ViewBag.LastName = userToCreate.LastName;
            return RedirectToAction("Merge");
        }
    }
}

