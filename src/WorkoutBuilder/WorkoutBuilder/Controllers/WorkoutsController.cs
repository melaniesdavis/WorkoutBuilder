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

        private Context db = new Context();

        // GET: Workouts
        public ActionResult Index()
        {
            var workouts = Repository.GetWorkouts();

            return View(workouts);
        }

        // Get Workout Details
        public ActionResult Details(int Id)
        {
            Workout workout = Repository.GetWorkout(Id);

            return View(workout);
        }

        // Get: Create Workout
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ViewModels.Workout();
            model.ExerciseList = Repository.GetExercises();
            model.RepSetList = Repository.GetRepSet();
            return View(model);
        }
    }
}

//ViewBag.exercises = Repository.GetExercises();
//            ViewBag.repsets = Repository.GetRepSet();