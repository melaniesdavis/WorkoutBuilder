using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkoutBuilder.Data;
using WorkoutBuilder.Models;

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

        public ActionResult Details(int Id)
        {
            Workout workout = Repository.GetWorkout(Id);

            return View(workout);
        }
    }
}