using PersonAction.Model;
using PersonAction.Model.Context;
using System.Collections.Generic;

namespace PersonAction.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);

        bool Exists(long? id);
    }
}
