using FluentValidation;

namespace BookStore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(command => command.AuthorId)
                .GreaterThan(0).WithMessage("Author ID must be greater than 0.");

            RuleFor(command => command.Model.Name)
                .NotEmpty().WithMessage("Author name is required.")
                .MaximumLength(100).WithMessage("Author name cannot exceed 100 characters.");

            RuleFor(command => command.Model.Surname)
                .NotEmpty().WithMessage("Author surname is required.")
                .MaximumLength(100).WithMessage("Author surname cannot exceed 100 characters.");
        }
    }
}
