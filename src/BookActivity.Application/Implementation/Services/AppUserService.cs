﻿using Ardalis.Result;
using AutoMapper;
using BookActivity.Application.Interfaces.Services;
using BookActivity.Application.Models;
using BookActivity.Application.Models.Dto.Create;
using BookActivity.Application.Models.Dto.Update;
using BookActivity.Domain.Commands.AppUserCommands.AddAppUser;
using BookActivity.Domain.Commands.AppUserCommands.SubscribeAppUser;
using BookActivity.Domain.Commands.AppUserCommands.UnsubscribeAppUser;
using BookActivity.Domain.Commands.AppUserCommands.UpdateAppUser;
using BookActivity.Domain.Interfaces;
using BookActivity.Domain.Queries.AppUserQueries.AuthenticationUser;
using BookActivity.Domain.Queries.AppUserQueries.GetCurrentUser;
using BookActivity.Domain.Validations;
using BookActivity.Shared.Models;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace BookActivity.Application.Implementation.Services
{
    internal class AppUserService : IAppUserService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediatorHandler;

        public AppUserService(IMapper mapper, IMediatorHandler mediatorHandler)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<ValidationResult> AddAsync(CreateUserDto appUserCreateDto)
        {
            appUserCreateDto.Validate();

            var addAppUserCommand = _mapper.Map<AddAppUserCommand>(appUserCreateDto);

            return await _mediatorHandler.SendCommandAsync(addAppUserCommand);
        }

        public async Task<ValidationResult> SubscribeAsync(Guid currentUserId, Guid subscribedUserId)
        {
            CommonValidator.ThrowExceptionIfEmpty(currentUserId, nameof(currentUserId));
            CommonValidator.ThrowExceptionIfEmpty(subscribedUserId, nameof(subscribedUserId));

            SubscribeAppUserCommand subscribeAppUserCommand = new(subscribedUserId, currentUserId);

            return await _mediatorHandler.SendCommandAsync(subscribeAppUserCommand);
        }

        public async Task<ValidationResult> UnsubscribeAsync(Guid currentUserId, Guid unsubscribedUserId)
        {
            CommonValidator.ThrowExceptionIfEmpty(currentUserId, nameof(currentUserId));
            CommonValidator.ThrowExceptionIfEmpty(unsubscribedUserId, nameof(unsubscribedUserId));

            UnsubscribeAppUserCommand subscribeAppUserCommand = new(unsubscribedUserId, currentUserId);

            return await _mediatorHandler.SendCommandAsync(subscribeAppUserCommand);
        }

        public async Task<ValidationResult> UpdateAsync(UpdateUserDto updateAppUserModel)
        {
            CommonValidator.ThrowExceptionIfEmpty(updateAppUserModel.UserId, nameof(updateAppUserModel.UserId));

            return await _mediatorHandler.SendCommandAsync(_mapper.Map<UpdateAppUserCommand>(updateAppUserModel));
        }

        public async Task<Result<AuthenticationResult>> AuthenticationAsync(AuthenticationModel authenticationModel)
        {
            CommonValidator.ThrowExceptionIfNull(authenticationModel);

            var query = _mapper.Map<AuthenticationUserQuery>(authenticationModel);

            return await _mediatorHandler.SendQueryAsync(query);
        }

        public async Task<CurrentUser> GetCurrentUserByIdAsync(Guid userId)
        {
            CommonValidator.ThrowExceptionIfEmpty(userId, nameof(userId));

            var query = new GetCurrentUserQuery(userId);

            return await _mediatorHandler.SendQueryAsync(query);
        }
    }
}
