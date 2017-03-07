using System.Data.Entity;
using WorkoutBuilder.Models;
using System;

namespace WorkoutBuilder.Data
{
    /// <summary>
    /// Custom database initializer class used to populate
    /// the database with seed data.
    /// </summary>
    
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            // This is our database's seed data...
            // 3 exercises, 2 sets of reps, and 1 workout.

            var exercisePlank = new Exercise()
            {
                Name = "Plank",
                Description = "Push-up position on elbows with forearms flat on floor."
            };

            var exercisePushUp = new Exercise()
            {
                Name = "Push-Up",
                Description = null
            };

            var exerciseDBSquat = new Exercise()
            {
                Name = "DB Squat",
                Description = "Squat with dumbbells."
            };

            var repSet1 = new RepSet()
            {
                Name = "1 x 30",
                Sets = 1,
                Reps = 30
            };

            var repSet2 = new RepSet()
            {
                Name = "3 x 15",
                Sets = 3,
                Reps = 15
            };

            var note1 = "Warm-up";

            var workout1 = new Workout()
            {
                Name = "Very Short Workout",
                Description = "This is a very short sample workout.",
            };

            workout1.AddExercise(exercisePlank, repSet1, note1);
            workout1.AddExercise(exerciseDBSquat, repSet2, null);
            workout1.AddExercise(exercisePushUp, repSet2, null);
            context.Workouts.Add(workout1);


            context.SaveChanges();
        }
    }
}