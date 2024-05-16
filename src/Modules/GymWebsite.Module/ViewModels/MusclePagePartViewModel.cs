using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymWebsite.Module.ViewModels
{
    public class MusclePagePartViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
