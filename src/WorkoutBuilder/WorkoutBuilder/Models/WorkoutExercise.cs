using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkoutBuilder.Models
{
    public class WorkoutExercise
    {

        public int Id { get; set; }
        
        public int WorkoutId { get; set; }
        
        public int ExerciseId { get; set; }
        
        public int RepSetId { get; set; }

        public Workout Workout { get; set; }

        public Exercise Exercise { get; set; }

        public RepSet RepSet { get; set; }

        //public ICollection<Exercise> ExerciseList { get; set; }

        //public ICollection<RepSet> RepSetList { get; set; }


        public string Notes { get; set; }
    }
}