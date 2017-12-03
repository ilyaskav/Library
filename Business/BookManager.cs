using AutoMapper;
using Business.ViewModels;
using System;
using Entity;
using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;

namespace Business
{
    public class BookManager
    {
        private LibraryEntities _context = null;
        private IMapper _mapper = null;

        public BookManager()
        {
            _context = new LibraryEntities();
            _mapper = EntityMapper.GetMapper();
        }

        public IEnumerable <BookModel> Get()
        {
            var books = _context.Books.AsQueryable().ProjectTo<BookModel>();
            return books;
        }

        public bool CreateBook (BookModel model)
        {
            model.CreatedAt = DateTime.Now;
            var book = _mapper.Map<BookModel, Book>(model);
            _context.Books.Add(book);

            return _context.SaveChanges() != 0;
        }
    }
}
