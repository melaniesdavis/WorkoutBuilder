﻿using System.Collections.Generic;

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
    }
}