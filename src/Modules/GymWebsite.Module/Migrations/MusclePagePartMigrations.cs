using GymWebsite.Module.Models;
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
    public class MusclePagePartMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private const string MusclePagePartName = $"{nameof(MusclePagePart)}FromCode";

        public MusclePagePartMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;

            // needed this in order for the method to be called
            CreateAsync().Wait();

        }

        public async Task<int> CreateAsync()
        {
            //await _contentDefinitionManager.AlterPartDefinitionAsync(MusclePagePartName, part => part
            // .Attachable());

            await _contentDefinitionManager.AlterTypeDefinitionAsync(MusclePagePartName, type => type
              .Creatable()
              .Listable()
              .Draftable()
              );

            return 1;
        }
    }
}
