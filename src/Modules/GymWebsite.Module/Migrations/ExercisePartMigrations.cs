using GraphQLParser;
using GymWebsite.Module.Models;
using OrchardCore.ContentFields.Fields;
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
    public class ExercisePartMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;
       // private const string ExercisePartName = $"{)}";

        public ExercisePartMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;

            // needed this in order for the method to be called
            CreateAsync().Wait();
        }

        public async Task<int> CreateAsync()
        {
            await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(ExercisePart), part => part
              .Attachable()
                .WithField("Description", field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Description"))
              //  .WithField("Type", field => field
              //    .OfType("TaxonomyField")
              //    .WithDisplayName("Type"))
              //.WithField(nameof(ExercisePart.Description), field => field
              //    .OfType(nameof(TextField))
              //    .WithDisplayName("Description")
              //    .WithEditor("TextArea"))
              );

            await _contentDefinitionManager.AlterTypeDefinitionAsync($"{nameof(ExercisePart)}PageFromCode", type => type
                 .Creatable()
                 .Listable()
                 .Draftable()
                 .WithPart(nameof(ExercisePart))
                 .WithPart("TitlePart")
             );

            return 1;
        }

        //public int UpdateFrom1()
        //{
        //     _contentDefinitionManager.AlterPartDefinitionAsync(ExercisePartName, part => part
        //      .Attachable()
        //      .WithField(nameof(ExercisePart.Description), field => field
        //          .OfType(nameof(TextField))
        //          .WithDisplayName("Description")
        //          .WithEditor("TextArea")));

        //    return 2;
        //}

    }
}
