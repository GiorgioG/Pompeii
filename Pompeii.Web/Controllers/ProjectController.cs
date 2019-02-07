using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pompeii.Web.Models.View;

namespace Pompeii.Web.Controllers
{
    public class ProjectController : Controller 
    { 
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

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }


        [Route("CheckName")]
        [HttpGet]
        public IActionResult CheckName([FromQuery] string name)
        {
            return Json(new { error=name=="bob"? null: "Invalid Team Name" });
        }


        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("Team")]
        public IActionResult Post(EditTeamViewModel model)
        {
            return View("Index");
        }

    }
}