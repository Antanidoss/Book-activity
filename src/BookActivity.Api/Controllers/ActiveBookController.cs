﻿using BookActivity.Api.Attributes;
using BookActivity.Api.Common.Constants;
using BookActivity.Api.Common.Extansions;
using BookActivity.Api.Common.Models;
using BookActivity.Application.Interfaces.Services;
using BookActivity.Application.Models.Dto.Create;
using BookActivity.Application.Models.Dto.Read;
using BookActivity.Application.Models.Dto.Update;
using BookActivity.Application.Models.HistoryData;
using BookActivity.Domain.Filters.Models;
using BookActivity.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet(ApiConstants.GetActiveBooksByIdsMethod)]
        public async Task<ApiResult<IEnumerable<ActiveBookDto>>> GetaActiveBooksByIdsAsync(Guid[] activeBookIds)
        {
            return (await _activeBookService.GetByActiveBookIdAsync(activeBookIds)
                .ConfigureAwait(false))
                .ToApiResult();
        }

        [HttpGet(ApiConstants.GetActiveBooksByUserIdMethod)]
        public async Task<ApiResult<IEnumerable<ActiveBookDto>>> GetaActiveBooksByUserIdsAsync(Guid userId, PaginationModel paginationModel)
        {
            return (await _activeBookService.GetByUserIdAsync(paginationModel, userId)
                .ConfigureAwait(false))
                .ToApiResult();
        }

        [HttpGet(ApiConstants.GetActiveBooksByFilterMethod)]
        public async Task<ApiResult<EntityListResult<SelectedActiveBook>>> GetActiveBooksByFilterAsync(GetActiveBookByFilterDto filterModel)
        {
            if (filterModel.UserId == Guid.Empty)
                filterModel.UserId = _currentUser.Id;

            return (await _activeBookService.GetByFilterAsync(filterModel)
                .ConfigureAwait(false))
                .ToApiResult();
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