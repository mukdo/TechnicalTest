using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechicalTest.Web.Areas.Admin.Models;
using TT.Framework;

namespace TechicalTest.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Administrator")]
    public class DashboardController : Controller
    {
        private TTDbContext _dbContext;
        public DashboardController(TTDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            
           // ViewBag.countStudentRegistration = _sMDbContext.StudentRegistrations.Count();
            var model = new DashBoardModel();
            
            return View(model);

        } 
    }
}