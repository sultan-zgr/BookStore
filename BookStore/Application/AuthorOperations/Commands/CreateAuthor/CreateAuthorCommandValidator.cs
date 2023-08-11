using FluentValidation;
using System;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand.CreateAuthorViewModel>
    {
        public CreateAuthorValidator()
        {
            RuleFor(authorViewModel => authorViewModel.Name)
                .NotEmpty().WithMessage("Author name is required.")
                .MaximumLength(100).WithMessage("Author name cannot exceed 100 characters.");

            RuleFor(authorViewModel => authorViewModel.Surname)
                .NotEmpty().WithMessage("Author surname is required.")
                .MaximumLength(100).WithMessage("Author surname cannot exceed 100 characters.");

            RuleFor(authorViewModel => authorViewModel.Birthday)
                .NotEmpty().WithMessage("Author birthday is required.")
                .Must(BeAValidDate).WithMessage("Invalid birthday format.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }

}

