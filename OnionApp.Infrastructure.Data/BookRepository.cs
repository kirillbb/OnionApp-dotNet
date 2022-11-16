using Microsoft.EntityFrameworkCore;
using OnionApp.Domain.Core;
using OnionApp.Domain.Interfaces;

namespace OnionApp.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private OrderContext dbContext;

        public BookRepository()
        {
            this.dbContext = new OrderContext();
        }

        public IEnumerable<Book> GetBookList()
        {
            return dbContext.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return dbContext.Books.Find(id);
        }

        public void Create(Book book)
        {
            dbContext.Books.Add(book);
        }

        public void Update(Book book)
        {
            dbContext.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Book book = dbContext.Books.Find(id);
            if (book != null)
                dbContext.Books.Remove(book);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
