using GymWebsite.Module.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymWebsite.Module.ViewModels
{
    public class ExercisePartViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public ExerciseType Type { get; set; }
    }
}
