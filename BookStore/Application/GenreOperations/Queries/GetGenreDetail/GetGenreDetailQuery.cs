using AutoMapper;
using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    { 
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            GenreDetailViewModel wm = new GenreDetailViewModel();
            if (genre is null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }
            wm.Id = GenreId;
            wm.Name = genre.Name;
            return wm;


        }
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
