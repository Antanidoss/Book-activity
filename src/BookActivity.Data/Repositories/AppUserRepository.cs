﻿using BookActivity.Domain.Filters.Models;
using BookActivity.Domain.Interfaces.Filters;
using BookActivity.Domain.Interfaces.Repositories;
using BookActivity.Domain.Models;
using BookActivity.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookActivity.Infrastructure.Data.Repositories
{
    public sealed class AppUserRepository : IAppUserRepository
    {
        private readonly BookActivityContext _db;

        private readonly IFilterHandler<AppUser, AppUserFilterModel> _filterHandler;

        private readonly UserManager<AppUser> _userManager;

        public AppUserRepository(BookActivityContext db, IFilterHandler<AppUser, AppUserFilterModel> filterHandler, UserManager<AppUser> userManager)
        {
            _db = db;
            _filterHandler = filterHandler;
            _userManager = userManager;
        }

        public IUnitOfWork UnitOfWork => _db;

        public async Task<IdentityResult> Addasync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IEnumerable<AppUser>> GetByFilterAsync(AppUserFilterModel filterModel)
        {
            return await _filterHandler.Handle(filterModel, _db.Users).ToListAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}