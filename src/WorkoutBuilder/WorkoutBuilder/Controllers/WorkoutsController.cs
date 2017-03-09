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

        // GET: Workout/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workout/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name, Description")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Workouts.Add(workout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workout);
        }


        // Get: Add Exercise to Workout
        [HttpGet]
        public ActionResult Add()
        {
            var model = new ViewModels.WorkoutViewModel();
            model.ExerciseList = Repository.GetExercises();
            model.RepSetList = Repository.GetRepSet();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add([Bind(Include = "WorkoutId, ExerciseId, RepSetId, Exercise, Workout, RepSet, Notes")] Models.WorkoutExercise model)
        {
            if (ModelState.IsValid)
            {
               
                //    db.Workouts.Add(workout);
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                using (var context = new Context())
                {
                    var workoutExercise = new WorkoutExercise()
                    {
                        ExerciseId = model.ExerciseId,
                        Notes = model.Notes,
                        RepSetId = model.RepSetId,
                        WorkoutId = model.WorkoutId,
                        Exercise = model.Exercise,
                        Workout = model.Workout,
                        RepSet = model.RepSet
                    };
                    //workoutExercise.ExerciseId = model.ExerciseId;
                    //workoutExercise.RepSetId = model.RepSetId;
                    //workoutExercise.Notes = model.Notes;

                    var workout = context.Workouts.FirstOrDefault(w => w.Id == model.WorkoutId);
                    workout.Workouts.Add(workoutExercise);
                    context.SaveChanges();
                    return RedirectToAction("Details",new { Id = workoutExercise.Id });
                }

            }
            throw new NotImplementedException("Something else");

        }
    }
}

//ViewBag.exercises = Repository.GetExercises();
//            ViewBag.repsets = Repository.GetRepSet();