namespace WorkoutBuilder.Data
{
    public class WorkoutExercise
    {

        public int Id { get; set; }

        public int WorkoutId { get; set; }

        public int ExerciseId { get; set; }

        public Workout Workout { get; set; }

        public Exercise Exercise { get; set; }
    }
}