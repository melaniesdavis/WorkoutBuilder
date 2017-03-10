using System;
using WorkoutBuilder.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutBuilder.Data
{
    public static class Repository
    {
        /// <summary>
        /// Private method that returns a database context.
        /// </summary>
        /// <returns>An instance of the Context class.</returns>
        public static Context GetContext()
        {
            var context = new Context();
            context.Database.Log = (message) => Debug.WriteLine(message);
            return context;
        }

        /// <summary>
        /// Returns a list of workouts ordered by the workout name. 
        /// </summary>
        /// <returns>An IList collection of Workout entity instances.</returns>
        public static IList<Workout> GetWorkouts()
        {
            using (Context context = GetContext())
            {
                return context.Workouts
                    .OrderBy(w => w.Name)
                    .ToList();
            }
        }

        /// <summary>
        /// Returns a single workout.
        /// </summary>
        /// <param name="workoutId">The workout ID to retrieve.</param>
        /// <returns>A fully populated Workout entity instance.</returns>
        public static Workout GetWorkout(int workoutId)
        {
            using (Context context = GetContext())
            {
                return context.Workouts
                    .Include(w => w.Exercises.Select(a => a.Exercise))
                    .Include(w => w.Exercises.Select(a => a.RepSet))
                    .Where(w => w.Id == workoutId)
                    .SingleOrDefault();
            }
        }

        /// <summary>
        /// Returns a list of exercises ordered by name.
        /// </summary>
        /// <returns>An IList collection of Exercise entity instances.</returns>
        public static IList<Exercise> GetExercises()
        {
            using (Context context = GetContext())
            {
                return context.Exercises
                    .OrderBy(a => a.Name)
                    .ToList();
            }
        }

        /// <summary>
        /// Returns a list of roles ordered by name.
        /// </summary>
        /// <returns>An IList collection of Role entity instances.</returns>
        public static IList<RepSet> GetRepSet()
        {
            using (Context context = GetContext())
            {
                return context.Repsets
                    .OrderBy(r => r.Name)
                    .ToList();
            }
        }

        /// <summary>
        /// Adds a workout.
        /// </summary>
        /// <param name="workout">The Workout entity instance to add.</param>
        public static void AddWorkout(Workout workout)
        {
            using (Context context = GetContext())
            {

                context.Workouts.Add(workout);


                foreach (WorkoutExercise exercise in workout.Exercises)
                {
                    if (exercise.Exercise != null && exercise.Exercise.Id > 0)
                    {
                        context.Entry(exercise.Exercise).State = EntityState.Unchanged;
                    }

                    if (exercise.RepSet != null && exercise.RepSet.Id > 0)
                    {
                        context.Entry(exercise.RepSet).State = EntityState.Unchanged;
                    }
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds an exercise.
        /// </summary>
        /// <param name="exercise">The Exercise entity instance to add.</param>
        public static void AddExercise(Exercise exercise)
        {
            using (Context context = GetContext())
            {

                context.Exercises.Add(exercise);


                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds a set of repetitions.
        /// </summary>
        /// <param name="repset">The RepSet entity instance to add.</param>
        public static void AddRepSet(RepSet repSet)
        {
            using (Context context = GetContext())
            {

                context.Repsets.Add(repSet);


                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a workout.
        /// </summary>
        /// <param name="workout">The Workout entity instance to update.</param>
        public static void UpdateWorkout(Workout workout)
        {
            using (Context context = GetContext())
            {
                {

                    context.Workouts.Attach(workout);
                    var workoutEntry = context.Entry(workout);
                    workoutEntry.State = EntityState.Modified;
                    

                    context.SaveChanges();

                }
            }
        }

        /// <summary>
        /// Deletes a workout.
        /// </summary>
        /// <param name="workoutId">The workout ID to delete.</param>
        public static void DeleteWorkout(int workoutId)
        {
            using (Context context = GetContext())
            {

                var workout = new Workout() { Id = workoutId };
                context.Entry(workout).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }


        public static Exercise GetExerciseById(int exerciseId)
        {
            using (Context context = GetContext())
            {
                return context.Exercises
                    .Where(e => e.Id == exerciseId)
                    .SingleOrDefault();
            }
        }

        public static Workout GetWorkoutById(int workoutId)
        {
            using (Context context = GetContext())
            {
                return context.Workouts
                   .Where(w => w.Id == workoutId)
                    .SingleOrDefault();
            }
        }

        public static RepSet GetRepSetById(int repSetId)
        {
            using (Context context = GetContext())
            {
                return context.Repsets
                    .Where(r => r.Id == repSetId)
                    .SingleOrDefault();
            }
        }

        public static int GetWorkoutExerciseCount()
        {
            using (Context context = GetContext())
            {
                return context.WorkoutExercises.Count();
                    
            }
        }

    }
}
