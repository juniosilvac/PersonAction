using PersonAction.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonAction.Repository.Implemetations
{
    public class BookRepositoryImpl : IBookRepository
    {
        private MySqlContext _context;

        public BookRepositoryImpl(MySqlContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != default) _context.Books.Remove(result);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(book.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return book;
        }

        public bool Exists(long? id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}
