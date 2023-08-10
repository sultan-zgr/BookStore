using FluentValidation;

namespace BookStore.BookOperations.GetBook
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBooksQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(x => x.BookID).NotEmpty().GreaterThan(0);
        }
    }
}
