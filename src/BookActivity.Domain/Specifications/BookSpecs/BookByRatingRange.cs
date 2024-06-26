﻿using Antanidoss.Specification.Abstract;
using BookActivity.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BookActivity.Domain.Specifications.BookSpecs
{
    public sealed class BookByRatingRange : Specification<Book>
    {
        private readonly float _averageRatingFrom;

        private readonly float _averageRatingTo;

        public BookByRatingRange(float averageRatingFrom, float averageRatingTo)
        {
            _averageRatingFrom = averageRatingFrom;
            _averageRatingTo = averageRatingTo;
        }

        public override Expression<Func<Book, bool>> ToExpression()
        {
            return b => _averageRatingFrom <= b.BookOpinions.Average(o => o.Grade) && _averageRatingTo >= b.BookOpinions.Average(o => o.Grade);
        }
    }
}
