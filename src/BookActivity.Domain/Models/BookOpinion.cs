using System;
using System.Collections.Generic;

namespace BookActivity.Domain.Models
{
    public sealed class BookOpinion : BaseEntity
    {
        /// <summary>
        /// User rating of the book
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Opinion Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Relation of opinion with the user
        /// </summary>
        public AppUser User { get; private set; }
        public Guid UserId { get; private set; }

        /// <summary>
        /// Relation of book opinion with the book
        /// </summary>
        public Book Book { get; private set; }
        public Guid BookId { get; private set; }

        /// <summary>
        /// Relation of book opinion with the response opinions
        /// </summary>
        public ICollection<ResponseOpinion> ResponseOpinions { get; set; }

        private BookOpinion() : base() { }
        public BookOpinion(int grade, string description, Guid userId, Guid bookId, bool isPublic) : base(isPublic)
        {
            Grade = grade;
            Description = description;
            UserId = userId;
            BookId = bookId;
            ResponseOpinions = new List<ResponseOpinion>();
        }
    }
}