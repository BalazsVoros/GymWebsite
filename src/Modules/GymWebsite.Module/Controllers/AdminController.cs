using GymWebsite.Module.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymWebsite.Module.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IContentManager _contentManager;
        public AdminController(IAuthorizationService authorizationService, IContentManager contentManager)
        {

            _authorizationService = authorizationService;
            _contentManager = contentManager;
        }
        public string Index()
        {
            return "OK";
        }

        public async Task<string> ContentAuthorization()
        {
            var exercisepage = await _contentManager.NewAsync("ExercisePageFromCode");

            var isAuthorized = await _authorizationService
                .AuthorizeAsync(User, CommonPermissions.EditContent, exercisepage);

            return $"Is authorized? {isAuthorized}";
        }

        public async Task<string> CustomAuthorization()
        {
            var isAuthorized = await _authorizationService
                .AuthorizeAsync(User, ExercisePermissions.ManageExercises);

            return $"Is authorized? {isAuthorized}";
        }
    }
}
