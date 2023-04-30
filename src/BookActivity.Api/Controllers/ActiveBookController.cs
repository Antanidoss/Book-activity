﻿using BookActivity.Api.Attributes;
using BookActivity.Api.Common.Constants;
using BookActivity.Api.Common.Extansions;
using BookActivity.Api.Common.Models;
using BookActivity.Application.Interfaces.Services;
using BookActivity.Application.Models.Dto.Create;
using BookActivity.Application.Models.Dto.Read;
using BookActivity.Application.Models.Dto.Update;
using BookActivity.Application.Models.HistoryData;
using Microsoft.AspNetCore.Mvc;

namespace BookActivity.Api.Controllers
{
    [Route(ApiConstants.ActiveBookService)]
    [Authorize]
    public sealed class ActiveBookController : BaseController
    {
        private readonly IActiveBookService _activeBookService;

        public ActiveBookController(IActiveBookService activeBookService, [FromServices] AppUserDto currentUser) : base(currentUser)
        {
            _activeBookService = activeBookService;
        }

        [HttpPost(ApiConstants.AddActiveBookMethod)]
        public async Task<ApiResult<Guid>> AddActiveBookAsync([FromBody] CreateActiveBookDto createActiveBookModel)
        {
            createActiveBookModel.UserId = _currentUser.Id;

            return (await _activeBookService.AddActiveBookAsync(createActiveBookModel)
                .ConfigureAwait(false))
                .ToApiResult();
        }

        [HttpPut(ApiConstants.UpdateNumberPagesReadMethod)]
        public async Task<ActionResult> UpdateNumberPagesReadAsync([FromBody] UpdateNumberPagesReadDto updateActiveBookModel)
        {
            updateActiveBookModel.UserId = _currentUser.Id;

            return (await _activeBookService.UpdateActiveBookAsync(updateActiveBookModel)
                .ConfigureAwait(false))
                .ToActionResult();
        }

        [HttpDelete(ApiConstants.RemoveActiveBookMethod)]
        public async Task<ActionResult> RemoveActiveBookAsync([FromQuery] Guid activeBookId)
        {
            return (await _activeBookService.RemoveActiveBookAsync(activeBookId)
                .ConfigureAwait(false))
                .ToActionResult();
        }

        [HttpGet(ApiConstants.GetActiveBookHistoryDataMethod)]
        public async Task<ApiResult<IEnumerable<ActiveBookHistoryData>>> GetActiveBookHistoryDataAsync(Guid activeBookId)
        {
            return (await _activeBookService.GetActiveBookHistoryDataAsync(activeBookId)
                .ConfigureAwait(false))
                .ToApiResult();
        }
    }
}