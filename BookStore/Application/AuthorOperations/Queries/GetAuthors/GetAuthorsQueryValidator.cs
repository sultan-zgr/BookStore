using FluentValidation;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQueryValidator : AbstractValidator<GetAuthorsQuery>
    {
        public GetAuthorsQueryValidator()
        {
            
        }
    }
}
