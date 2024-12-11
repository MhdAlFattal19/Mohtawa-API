
namespace Mohtawa.Domain.IRepositories
{
    public interface ILibraryUnitOfWork
    {
        IBookRepository BookRepository { get; }
        Task SaveAsync();
    }
}