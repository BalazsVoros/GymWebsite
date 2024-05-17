using OrchardCore.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymWebsite.Module.Permissions
{
    public class ExercisePermissions : IPermissionProvider
    {
        public static readonly Permission ManageExercises = new Permission("ManageExercises", "Create, Edit, Delete exercises");

        

        public Task<IEnumerable<Permission>> GetPermissionsAsync() =>
            Task.FromResult(new[]
            {
                ManageExercises,
            }
           .AsEnumerable());

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() =>
           new[]
           {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageExercises },
                },
                new PermissionStereotype
                {
                    Name = "ExerciseEditor",
                    Permissions = new[] { ManageExercises },
                },
           };
    }
}
