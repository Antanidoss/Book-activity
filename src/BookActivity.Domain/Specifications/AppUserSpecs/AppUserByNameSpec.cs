﻿using Antanidoss.Specification.Interfaces;
using BookActivity.Domain.Models;
using System;
using System.Linq.Expressions;

namespace BookActivity.Domain.Specifications.AppUserSpecs
{
    public sealed class AppUserByNameSpec : ISpecification<AppUser>
    {
        private readonly string _name;

        public AppUserByNameSpec(string name)
        {
            _name = name;
        }

        public Expression<Func<AppUser, bool>> ToExpression()
        {
            return a => a.UserName.Contains(_name);
        }
    }
}
