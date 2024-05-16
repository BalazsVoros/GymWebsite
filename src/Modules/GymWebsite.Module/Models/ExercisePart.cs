using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymWebsite.Module.Models
{
    public class ExercisePart : ContentPart
    {
        public string Name { get; set; }
        public TextField Description { get; set; }
        public ExerciseType Type { get; set; }
    }
    public enum ExerciseType
    {
        FreeWeight,
        Machine,
    }

}
