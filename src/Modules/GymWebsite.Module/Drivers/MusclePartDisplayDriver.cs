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
    public class MusclePartDisplayDriver : ContentPartDisplayDriver<MusclePart>
    {
        public override IDisplayResult Display(MusclePart part, BuildPartDisplayContext context) =>
           Initialize<MusclePartViewModel>(
               GetDisplayShapeType(context),
               viewModel => PopulateViewModel(part, viewModel))
           .Location("Detail", "Content:5")
           .Location("Summary", "Content:5");

        public override IDisplayResult Edit(MusclePart part, BuildPartEditorContext context) =>
            Initialize<MusclePartViewModel>(
                GetEditorShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Content:5");

        public override async Task<IDisplayResult> UpdateAsync(MusclePart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var viewModel = new MusclePartViewModel();

            await updater.TryUpdateModelAsync(viewModel, Prefix);

            part.Name = viewModel.Name;

            return await EditAsync(part, context);
        }


        private static void PopulateViewModel(MusclePart part, MusclePartViewModel viewModel)
        {
            viewModel.Name = part.Name;
        }
    }
}
