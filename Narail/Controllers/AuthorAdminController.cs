using Narail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers
{
    public class AuthorAdminController : Controller
    {

        // GET: AuthorAdmin
        public ActionResult Index()
        {
            using (NarailDBEntities db = new NarailDBEntities())
            {
                var a = db.Authors.ToList();
                return View(a);
            }
        }
    }
}