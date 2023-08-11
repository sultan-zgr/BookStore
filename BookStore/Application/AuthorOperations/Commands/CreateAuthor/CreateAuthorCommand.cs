using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly CreateAuthorViewModel authorViewModel;
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;


        public CreateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(CreateAuthorViewModel createAuthorViewModel)
        {
            var author = _dbContext.Authors.SingleOrDefault(a => a.Name == authorViewModel.Name);

            if (author is not null)
                throw new InvalidOperationException("Author is already added.");

            author = _mapper.Map<Author>(authorViewModel);

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();

        }

        public class CreateAuthorViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Birthday { get; set; }
        }
    }
}
