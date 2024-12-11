using Mohtawa.Domain.IRepositories;
using Mohtawa.Infrastructure.Repositories;

namespace Mohtawa.Infrastructure.Contexts
{
    public class LibraryUnitOfWork : ILibraryUnitOfWork
    {
        private readonly LibraryContext _context;

        public LibraryUnitOfWork(LibraryContext context)
        {
            _context = context;
        }

        public IBookRepository BookRepository
        {
            get
            {
                return new BookRepository(_context);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}