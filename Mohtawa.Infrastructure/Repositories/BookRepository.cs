using Microsoft.EntityFrameworkCore;
using Mohtawa.Domain.IRepositories;
using Mohtawa.Domain.Models;
using Mohtawa.Infrastructure.Contexts;

namespace Mohtawa.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        #region Properties
        private readonly LibraryContext _context;
        #endregion

        #region Methods
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }
        public void Update(Book book)
        {
            _context.Books.Attach(book);
            _context.Entry(book).State = EntityState.Modified;
        }
        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }
        #endregion
    }
}