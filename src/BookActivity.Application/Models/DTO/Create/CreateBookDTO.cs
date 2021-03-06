using System;
using System.Collections.Generic;

namespace BookActivity.Application.Models.DTO.Create
{
    public sealed class CreateBookDTO : BaseCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Guid> AuthorIds { get; private set; }

        public CreateBookDTO() { }

        public CreateBookDTO(string title, string description, IEnumerable<Guid> authorIds) : base()
        {
            Title = title;
            Description = description;
            AuthorIds = authorIds;
        }
    }
}
