using GymWebsite.Module.Models;
using OrchardCore.ContentManagement.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymWebsite.Module.Handlers
{
    public class ExercisePartHandler : ContentPartHandler<ExercisePart>
    {
        public override Task UpdatedAsync(UpdateContentContext context, ExercisePart instance)
        {
            context.ContentItem.DisplayText = instance.Name;
            return Task.CompletedTask;
        }
    }
}
