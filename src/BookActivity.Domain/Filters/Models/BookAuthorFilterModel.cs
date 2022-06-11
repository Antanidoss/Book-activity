﻿using BookActivity.Domain.Interfaces.Filters;
using BookActivity.Domain.Models;
using System;

namespace BookActivity.Domain.Filters.Models
{
    public sealed class BookAuthorFilterModel : BaseFilterModel
    {
        public IQueryableFilterSpec<BookAuthor> Filter { get; set; }

        public BookAuthorFilterModel(int skip = SkipDefault, int take = TakeDefault) : base(skip, take) { }
        public BookAuthorFilterModel(IQueryableFilterSpec<BookAuthor> filter, int skip = SkipDefault, int take = TakeDefault) : base(skip, take)
        {
            Filter = filter;
        }
    }
}
