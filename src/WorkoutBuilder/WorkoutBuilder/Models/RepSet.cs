using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutBuilder.Models
{
    /// <summary>
    /// Represents a set of repititions.
    /// </summary>
    public class RepSet
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}
