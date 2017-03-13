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
        //public WorkoutViewModel()
        //{
        //    Exercise = new List<WorkoutExercise>();
        //}

        public int Id { get; set; }

        public string WorkoutName { get; set; }

        public string WorkoutDescription { get; set; }

        public int WorkoutId { get; set; }

        public int ExerciseId { get; set; }

        public int RepSetId { get; set; }

        //public ICollection<WorkoutExercise> Exercise { get; set; }

        public ICollection<Exercise> ExerciseList { get; set; }

        public ICollection<RepSet> RepSetList { get; set; }

        public string Notes { get; set; }
    }
}
