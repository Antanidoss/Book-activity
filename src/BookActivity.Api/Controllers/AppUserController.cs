using BookActivity.Api.Common.Constants;
using BookActivity.Api.Common.Extansions;
using BookActivity.Api.Common.Models;
using BookActivity.Application.Interfaces.Services;
using BookActivity.Application.Models;
using BookActivity.Application.Models.DTO.Create;
using BookActivity.Application.Models.DTO.Read;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookActivity.Api.Controllers
{
    [Route(ApiConstants.AppUserService)]
    public sealed class AppUserController : BaseController
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _appUserService = appUserService;
        }

        [HttpPost(ApiConstants.AddUserMethod)]
        public async Task<IActionResult> AddAppUserAsync([FromBody] AppUserCreateDTO appUserCreateDTO)
        {
            return (await _appUserService.AddAsync(appUserCreateDTO).ConfigureAwait(false)).ToActionResult();
        }

        [HttpGet(ApiConstants.GetUserByIdMethod)]
        public async Task<ApiResult<AppUserDTO>> GetAppUserByIdAsync(Guid appUserId)
        {
            return (await _appUserService.FindByIdAsync(appUserId).ConfigureAwait(false))
                .ToApiResult();
        }

        [HttpPost(ApiConstants.AuthenticationMethod)]
        public async Task<ApiResult<AuthenticationResult>> AuthenticationAsync([FromBody] AuthenticationModel authenticationModel)
        {
            return (await _appUserService.PasswordSignInAsync(authenticationModel).ConfigureAwait(false))
                .ToApiResult();
        }

        [HttpPut(ApiConstants.SubscribeAppUserMethod)]
        public async Task<ActionResult> SubscribeAppUserAsync(Guid subscribedUserId)
        {
            var currentUser = GetCurrentUser();

            return (await _appUserService.SubscribeAppUserAsync(currentUser.Id, subscribedUserId).ConfigureAwait(false))
                .ToActionResult();
        }
    }
}
