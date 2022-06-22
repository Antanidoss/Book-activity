﻿using BookActivity.Domain.Models;
using QueryableFilterSpecification.Interfaces;

namespace BookActivity.Domain.Filters.Models
{
    public sealed class ActiveBookFilterModel : BaseFilterModel
    {
        public IQueryableFilterSpec<ActiveBook> Filter { get; set; }

        public ActiveBookFilterModel(int? skip = SkipDefault, int? take = TakeDefault) : base(skip, take) { }
        public ActiveBookFilterModel(IQueryableFilterSpec<ActiveBook> filter, int? skip = SkipDefault, int? take = TakeDefault) : base(skip, take)
        {
            Filter = filter;
        }
    }
}
