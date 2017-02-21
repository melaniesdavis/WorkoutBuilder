using System.Collections.Generic;

namespace WorkoutBuilder.Data
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

        public int Sets { get; set; }

        public int Reps { get; set; }

        public ICollection<WorkoutExercise> Exercises { get; set; }
    }
}