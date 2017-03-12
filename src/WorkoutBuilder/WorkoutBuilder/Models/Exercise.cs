using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkoutBuilder.Models
{
    public class Exercise
    {
        public Exercise()
        {
            Workouts = new List<WorkoutExercise>();
        }

        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<WorkoutExercise> Workouts { get; set; }
    }
}