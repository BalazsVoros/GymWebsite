using GymWebsite.Module.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public AdminController(IAuthorizationService authorizationService)
        {

            _authorizationService = authorizationService;
        }
        public string Index()
        {
            return "OK";
        }

        public async Task<string> CustomAuthorization()
        {
            var isAuthorized = await _authorizationService
                .AuthorizeAsync(User, ExercisePermissions.ManageExercises);

            return $"Is authorized? {isAuthorized}";
        }
    }
}
