﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            vm.Teams = new List<TeamViewModel>()
            {
                new TeamViewModel() {Id = Guid.NewGuid(), Name = "Team 1"},
                new TeamViewModel() {Id = Guid.NewGuid(), Name = "Team 2"},
                new TeamViewModel() {Id = Guid.NewGuid(), Name = "Team 3"}
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