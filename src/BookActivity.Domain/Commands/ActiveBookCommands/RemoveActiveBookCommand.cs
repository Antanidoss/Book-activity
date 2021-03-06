using BookActivity.Domain.Commands.ActiveBookCommands.Validations;
using System;

namespace BookActivity.Domain.Commands.ActiveBookCommands
{
    public sealed class RemoveActiveBookCommand : ActiveBookCommand
    {
        public RemoveActiveBookCommand(Guid activeBookId)
        {
            Id = activeBookId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveActiveBookCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}