using OrchardCore.ContentFields.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymWebsite.Module.ViewModels
{
    public class ExercisePart
    {
        public string Title { get; set; }
        public TextField Description { get; set; }
        public ExerciseType Type { get; set; }
    }
    public enum ExerciseType
    {
        FreeWeight,
        Machine,
    }

}
