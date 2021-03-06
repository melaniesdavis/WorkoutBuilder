﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkoutBuilder.Models
{
    public class Workout
    {
        public Workout()
        {
            Exercises = new List<WorkoutExercise>();
        }

        public int Id { get; set; }

        [Required, StringLength(200)]
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
        public void AddExercise(Exercise exercise, RepSet repSet, string note)
        {
            Exercises.Add(new WorkoutExercise()
            {
                Exercise = exercise,
                RepSet = repSet, 
                Notes = note
            });
        }

        /// <summary>
        /// Adds an exercise to the workout.
        /// </summary>
        /// <param name="exercisetId">The exercise ID to add.</param>
        /// <param name="repsetId">The repset ID that the exercise had on this workout.</param>
        public void AddExercise(int exerciseId, int repSetId, string note)
        {
            Exercises.Add(new WorkoutExercise()
            {
                ExerciseId = exerciseId,
                RepSetId = repSetId,
                Notes = note
            });
        }
    }
}