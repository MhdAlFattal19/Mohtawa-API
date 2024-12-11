using Mohtawa.Domain.Models;

namespace Mohtawa.Domain.IRepositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task AddAsync(Book book);
        void Update(Book book);
        void Delete(Book bookd);
    }
}