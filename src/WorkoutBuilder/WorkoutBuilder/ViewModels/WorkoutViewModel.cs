using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutBuilder.Models;

namespace WorkoutBuilder.ViewModels
{
    public class WorkoutViewModel
    {
        public WorkoutViewModel()
        {
            Exercises = new List<WorkoutExercise>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public ICollection<WorkoutExercise> Exercises { get; set; }

        public ICollection<Exercise> ExerciseList { get; set; }

        public ICollection<RepSet> RepSetList { get; set; }

        public string Notes { get; set; }
    }
}
