using GymWebsite.Module.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymWebsite.Module.Migrations
{
    public class MusclePartMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private const string MusclePartName = $"{nameof(MusclePart)}FromCode";

        public MusclePartMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;

            // needed this in order for the method to be called
            CreateAsync().Wait();

        }

        public async Task<int> CreateAsync()
        {
            await _contentDefinitionManager.AlterPartDefinitionAsync(MusclePartName, part => part
             .Attachable()
             .WithField("Name", field => field
                  .OfType("TextField")
                  .WithDisplayName("Name")
                  .WithEditor("TextArea")));

            await _contentDefinitionManager.AlterTypeDefinitionAsync($"{nameof(MusclePart)}PageFromCode", type => type
              .Creatable()
              .Listable()
              .Draftable()
              .WithPart(MusclePartName )
              .WithPart("AutoRoutePart")
              .WithPart("ListPart", builder => builder 
                .WithSetting("ListPartSettings.ContainedContentTypes", $"{nameof(ExercisePart)}PageFromCode")
                
            )
              );

            return 1;
        }

        //public int UpdateFrom1()
        //{
        //     _contentDefinitionManager.AlterTypeDefinitionAsync(MusclePagePartName, type => type
        //    .Creatable()
        //    .Listable()
        //    .Draftable()
        //    );

        //    return 2;
        //}
    }
}
