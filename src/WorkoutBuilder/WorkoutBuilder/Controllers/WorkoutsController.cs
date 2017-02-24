using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkoutBuilder.Data;

namespace WorkoutBuilder.Views.Workouts
{
    public class WorkoutsController : Controller
    {
        // GET: Workouts
        public ActionResult Index()
        {
            var workouts = Repository.GetWorkouts();

            return View(workouts);
        }
    }
}