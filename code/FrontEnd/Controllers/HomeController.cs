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
using Microsoft.Extensions.Options;
using FrontEnd.Repositories;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private AppSettings Configuration;
       private readonly ILogger<HomeController> _logger;
        private IRepositoryWrapper repository;
        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> settings, IRepositoryWrapper repositoryWrapper)
        {
         _logger = logger;
            Configuration = settings.Value;
            repository = repositoryWrapper;
        }

       
        public async Task<IActionResult> Merge()  //method
        {
            var mergedService = $"{Configuration.mergedServiceURL}/merge";
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
            repository.UserInput.Create(userToCreate);
            repository.Save();
            ViewBag.FirstName = userToCreate.FirstName;
            ViewBag.LastName = userToCreate.LastName;
            return RedirectToAction("Merge");
        }
    }
}

