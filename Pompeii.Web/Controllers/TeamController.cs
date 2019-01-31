using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pompeii.Web.Models.View;

namespace Pompeii.Web.Controllers
{
    public class TeamController : Controller 
    { 
        public IActionResult Index()
        {
            var vm = new HomeViewModel();
            vm.Teams = new List<TeamViewModel>()
            {
                new TeamViewModel() {Id = Guid.NewGuid(), Name = "Team 1"},
                new TeamViewModel() {Id = Guid.NewGuid(), Name = "Team 2"},
                new TeamViewModel() {Id = Guid.NewGuid(), Name = "Team 3"}
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewPost()
        {
            return View("Index");
        }

    }
}