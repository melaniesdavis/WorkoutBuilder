using System.Collections.Generic;

namespace WorkoutBuilder.Models
{
    public class Workout
    {
        public Workout()
        {
            Exercises = new List<WorkoutExercise>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //public int Sets { get; set; }

        //public int Reps { get; set; }

        public ICollection<WorkoutExercise> Exercises { get; set; }

        /// <summary>
        /// Adds an exercise to the workout.
        /// </summary>
        /// <param name="exercise">The exercise to add.</param>
        /// <param name="repset">The set of reps that the exercise had in this workout.</param>
        public void AddExercise(Exercise exercise, RepSet repSet)
        {
            Exercises.Add(new WorkoutExercise()
            {
                Exercise = exercise,
                RepSet = repSet
            });
        }

        /// <summary>
        /// Adds an artist to the comic book.
        /// </summary>
        /// <param name="exercisetId">The artist ID to add.</param>
        /// <param name="repsetId">The role ID that the artist had on this comic book.</param>
        public void AddExercise(int exerciseId, int repsetId)
        {
            Exercises.Add(new WorkoutExercise()
            {
                ExerciseId = exerciseId,
                RepSetId = repsetId
            });
        }
    }
}