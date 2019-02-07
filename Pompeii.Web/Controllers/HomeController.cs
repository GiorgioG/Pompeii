using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pompeii.Web.Models;
using Pompeii.Web.Models.View;

namespace Pompeii.Web.Controllers
{
    public class HomeController : Controller 
    {
        
        [Route("")]
        public IActionResult Index()
        {
            var vm = new HomeViewModel();
            vm.Projects = new List<ProjectSimpleViewModel>()
            {
                new ProjectSimpleViewModel() {Id = Guid.NewGuid(), Name = "Project 1"},
                new ProjectSimpleViewModel() {Id = Guid.NewGuid(), Name = "Project 2"},
                new ProjectSimpleViewModel() {Id = Guid.NewGuid(), Name = "Project 3"}
            };
            return View(vm);
        }

        
        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}