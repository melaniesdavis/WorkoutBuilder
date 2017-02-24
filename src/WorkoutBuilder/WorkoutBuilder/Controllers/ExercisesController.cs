using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkoutBuilder.Data;
using WorkoutBuilder.Models;
using System.Data.Entity;

namespace WorkoutBuilder.Controllers
{
    public class ExercisesController : Controller
    {
        // GET: Exercise
        public ActionResult Index()
        {
            var exercise = Repository.GetExercises();

            return View(exercise);
        }


    }
}