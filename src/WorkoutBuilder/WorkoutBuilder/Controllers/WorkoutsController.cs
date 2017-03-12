using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult Add(int id, int exerciseId, int repSetId, string note, Exercise exercise, RepSet repSet, Workout workout, WorkoutExercise model)
        {
            var workoutExercise = new WorkoutExercise()
                {
                    Id = Repository.GetWorkoutExerciseCount() + 1,
                    ExerciseId = exerciseId,
                    Notes = note,
                    RepSetId = repSetId,
                    WorkoutId = id,
                    Exercise = Repository.GetExerciseById(exerciseId),
                    RepSet = Repository.GetRepSetById(repSetId),
                    Workout = Repository.GetWorkoutById(id)
                };

            var workoutToUpdate = db.Workouts.FirstOrDefault(w => w.Id == id);
            workoutToUpdate.AddExercise(exerciseId, repSetId, note);
            db.SaveChanges();
            return RedirectToAction("Details", new { Id = id });
        }



        // GET: Workouts/Edit/
        [HttpGet]
        public ActionResult EditWorkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Edit
        [HttpPost, ActionName("EditWorkout")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, Workout workout)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var workoutToUpdate = db.Workouts.Find(id);
            if (TryUpdateModel(workoutToUpdate, "", new string[] { "Name", "Description" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (System.Data.DataException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes.  Try again.");
                }
            }
            return View(workoutToUpdate);

        }

        // GET: Workout/Delete/
        [HttpGet]
        public ActionResult DeleteWorkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workout/Delete/
        [HttpPost, ActionName("DeleteWorkout")]
        public ActionResult DeleteConfirmed(int id)
        {
            Workout workout = db.Workouts.Find(id);
            db.Workouts.Remove(workout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: WorkoutExercise/Edit/
        [HttpGet]
        public ActionResult EditWorkoutExercise(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutExercise workoutExercise = db.WorkoutExercises.Find(id);
            if (workoutExercise == null)
            {
                return HttpNotFound();
            }

            workoutExercise.ExerciseList = Repository.GetExercises();
            workoutExercise.RepSetList = Repository.GetRepSet();
            return View(workoutExercise);
        }
    }
}


