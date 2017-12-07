using AutoMapper;
using Business.ViewModels;
using System;
using Entity;
using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using System.Data.Entity;

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
            var books = _context.Books.AsQueryable().ProjectTo<BookModel>().ToList();
            return books;
        }

        public bool CreateBook (BookModel model)
        {
            model.CreatedAt = DateTime.Now;
            var book = _mapper.Map<BookModel, Book>(model);
            _context.Books.Add(book);

            return _context.SaveChanges() != 0;
        }

        public bool UpdateBook(BookModel model)
        {
            if (model.Id == 0)
            {
                return false;
            }

            var book = _context.Books.Single(b => b.Id == model.Id);
            _mapper.Map(model, book);
            _context.Entry(book).State = EntityState.Modified;

            return _context.SaveChanges() != 0;
        }

        public bool DeleteBook(int bookId)
        {
            if (bookId == 0)
            {
                return false;
            }

            var book = _context.Books.Single(b => b.Id == bookId);
            _context.Entry(book).State = EntityState.Deleted;

            return _context.SaveChanges() != 0;
        }
    }
}
