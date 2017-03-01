using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkoutBuilder.Data;

namespace WorkoutBuilder.Controllers
{
    public class RepSetsController : Controller
    {
        // GET: RepSets
        public ActionResult Index()
        {
            var repset = Repository.GetRepSet();

            return View(repset);
        }
    }
}