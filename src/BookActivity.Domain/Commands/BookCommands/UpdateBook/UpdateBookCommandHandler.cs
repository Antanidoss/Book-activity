﻿using Antanidoss.Specification.Filters.Implementation;
using BookActivity.Domain.Events.BookEvents;
using BookActivity.Domain.Interfaces.Repositories;
using BookActivity.Domain.Models;
using BookActivity.Domain.Specifications.BookSpecs;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace BookActivity.Domain.Commands.BookCommands.UpdateBook
{
    internal sealed class UpdateBookCommandHandler : CommandHandler,
        IRequestHandler<UpdateBookCommand, ValidationResult>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ValidationResult> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            BookByIdSpec bookByIdSpec = new(request.BookId);
            FirstOrDefault<Book> firstOrDefaultFilter = new(bookByIdSpec);
            var updatedBook = _bookRepository.GetByFilterAsync(firstOrDefaultFilter);

            updatedBook.Title = request.Title;
            updatedBook.Description = request.Description;
            updatedBook.ImageData = request.ImageData;

            updatedBook.AddDomainEvent(new UpdateBookEvent(updatedBook.Id, updatedBook.Title, updatedBook.Description, request.AuthorIds, updatedBook.IsPublic));
            _bookRepository.Update(updatedBook);

            return await Commit(_bookRepository.UnitOfWork).ConfigureAwait(false);
        }
    }
}
