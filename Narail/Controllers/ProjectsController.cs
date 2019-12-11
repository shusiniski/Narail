using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            ViewBag.Title = "Narail | Projects";
            return View();
        }
    }
}