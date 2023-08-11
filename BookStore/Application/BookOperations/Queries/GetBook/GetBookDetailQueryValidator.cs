using FluentValidation;

namespace BookStore.Application.BookOperations.Queries.GetBook
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBooksQuery>
    {
        public GetBookDetailQueryValidator()
        {

        }
    }
}
