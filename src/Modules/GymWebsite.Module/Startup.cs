using GymWebsite.Module.Drivers;
using GymWebsite.Module.Migrations;
using GymWebsite.Module.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace GymWebsite.Module
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<ExercisePart>().UseDisplayDriver<ExercisePartDisplayDriver>();
            services.AddContentPart<MusclePagePart>().UseDisplayDriver<MusclePagePartDisplayDriver>();

            services.AddScoped<IDataMigration, ExercisePartMigrations>();
            services.AddScoped<IDataMigration, MusclePagePartMigrations>();

        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "GymWebsite.Module",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
