using FluentValidation;

namespace BookStore.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(command => command.AuthorId)
                .GreaterThan(0).WithMessage("Author ID must be greater than 0.");
        }
    }
}
