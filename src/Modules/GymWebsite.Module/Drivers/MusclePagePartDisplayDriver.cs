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
    public class MusclePagePartDisplayDriver : ContentPartDisplayDriver<MusclePagePart>
    {
        public override IDisplayResult Display(MusclePagePart part, BuildPartDisplayContext context) =>
           Initialize<MusclePagePartViewModel>(
               GetDisplayShapeType(context),
               viewModel => PopulateViewModel(part, viewModel))
           .Location("Detail", "Content:5")
           .Location("Summary", "Content:5");

        public override IDisplayResult Edit(MusclePagePart part, BuildPartEditorContext context) =>
            Initialize<MusclePagePartViewModel>(
                GetEditorShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Content:5");

        public override async Task<IDisplayResult> UpdateAsync(MusclePagePart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var viewModel = new MusclePagePartViewModel();

            await updater.TryUpdateModelAsync(viewModel, Prefix);

            part.Name = viewModel.Name;

            return await EditAsync(part, context);
        }


        private static void PopulateViewModel(MusclePagePart part, MusclePagePartViewModel viewModel)
        {
            viewModel.Name = part.Name;
        }
    }
}
