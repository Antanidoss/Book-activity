﻿using BookActivity.Domain.Models;
using System;
using System.Collections.Generic;

namespace BookActivity.Domain.Commands.BookCommands
{
    public abstract class BookCommand : Command
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Guid> AuthorIds { get; set; }
        public IEnumerable<Guid> CategoryIds { get; set; }
        public IEnumerable<BookOpinion> BookOpinions { get; set; }
        public byte[] ImageData { get; set; }
    }
}