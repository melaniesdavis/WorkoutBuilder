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
        public ActionResult Add(int id)
        {
            
            var workoutExercise = new ViewModels.WorkoutViewModel();
            workoutExercise.ExerciseList = Repository.GetExercises();
            workoutExercise.RepSetList = Repository.GetRepSet();
            return View(workoutExercise);
        }

        [HttpPost]
        public ActionResult Add(int id, int exerciseId, int repSetId, string note, Exercise exercise, RepSet repSet, Workout workout, Models.WorkoutExercise model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {

                    var workoutExercise = new WorkoutExercise()
                    {
                        Id = Repository.GetWorkoutExerciseCount() +1,
                        ExerciseId = exerciseId,
                        Notes = note,
                        RepSetId = repSetId,
                        WorkoutId = id,
                        Exercise = Repository.GetExerciseById(exerciseId),
                        RepSet = Repository.GetRepSetById(repSetId),
                        Workout = Repository.GetWorkoutById(id)
                    };

                    var workoutToUpdate = context.Workouts.FirstOrDefault(w => w.Id == id);
                    workoutToUpdate.AddExercise(exerciseId , repSetId, note);
                    context.SaveChanges();
                    return RedirectToAction("Details", new { Id = id });
                }

            }
            throw new NotImplementedException("Something else");
        }

        
    }
}

//ViewBag.exercises = Repository.GetExercises();
//            ViewBag.repsets = Repository.GetRepSet();