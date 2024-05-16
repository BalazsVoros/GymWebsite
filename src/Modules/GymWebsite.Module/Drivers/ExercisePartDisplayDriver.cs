using GymWebsite.Module.Models;
using GymWebsite.Module.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymWebsite.Module.Drivers
{
    public class ExercisePartDisplayDriver : ContentPartDisplayDriver<ExercisePart>
    {
        public override IDisplayResult Display(ExercisePart part, BuildPartDisplayContext context) =>
           Initialize<ExercisePartViewModel>(
               GetDisplayShapeType(context),
               viewModel => PopulateViewModel(part, viewModel))
           .Location("Detail", "Content:5")
           .Location("Summary", "Content:5");

        public override IDisplayResult Edit(ExercisePart part, BuildPartEditorContext context) =>
            Initialize<ExercisePartViewModel>(
                GetEditorShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Content:5");

        public override async Task<IDisplayResult> UpdateAsync(ExercisePart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var viewModel = new ExercisePartViewModel();

            await updater.TryUpdateModelAsync(viewModel, Prefix);

            part.Name = viewModel.Name;
            part.Type = viewModel.Type;

            return await EditAsync(part, context);
        }


        private static void PopulateViewModel(ExercisePart part, ExercisePartViewModel viewModel)
        {
            viewModel.Name = part.Name;
            viewModel.Type = part.Type;

        }
    }
}
