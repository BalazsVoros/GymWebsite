﻿using GraphQLParser;
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
    }
}
