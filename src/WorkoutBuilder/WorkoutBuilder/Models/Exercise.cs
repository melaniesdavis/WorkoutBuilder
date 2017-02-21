using System.Collections.Generic;

namespace WorkoutBuilder.Data
{
    public class Exercise
    {
        public Exercise()
        {
            Workouts = new List<WorkoutExercise>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<WorkoutExercise> Workouts { get; set; }
    }
}