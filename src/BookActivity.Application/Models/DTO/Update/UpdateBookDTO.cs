﻿using System;

namespace BookActivity.Application.Models.DTO.Update
{
    public sealed class UpdateBookDto
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
