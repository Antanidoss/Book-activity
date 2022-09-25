﻿using Ardalis.Result;
using BookActivity.Application.Models.DTO.Create;
using BookActivity.Application.Models.DTO.Read;
using BookActivity.Application.Models.DTO.Update;
using BookActivity.Application.Models.HistoryData;
using BookActivity.Domain.FilterModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookActivity.Application.Interfaces.Services
{
    public interface IActiveBookService
    {
        Task<Result<Guid>> AddActiveBookAsync(CreateActiveBookDto createActiveBookModel);
        Task<ValidationResult> RemoveActiveBookAsync(Guid activeBookId);
        Task<ValidationResult> UpdateActiveBookAsync(UpdateNumberPagesReadDto updateActiveBookModel);
        Task<Result<IEnumerable<ActiveBookDto>>> GetByActiveBookIdAsync(Guid[] activeBookIds);
        Task<Result<IEnumerable<ActiveBookDto>>> GetByUserIdAsync(PaginationModel paginationModel, Guid currentUserId);
        Task<Result<IEnumerable<ActiveBookHistoryData>>> GetActiveBookHistoryDataAsync(Guid activeBookId);
    }
}