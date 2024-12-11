using Mohtawa.Domain.Requests;
using Mohtawa.Domain.Responses;

namespace Mohtawa.Domain.Contracts
{
    public interface IBookService
    {
        Task<AddBookResponse> AddAsync(AddBookRequest request);
        Task<DeleteBookResponse> DeleteAsync(int id,DeleteBookRequest request);
        Task<GetBookResponse> GetAsync(int id);
        Task<GetBooksResponse> GetListAsync();
        Task<AddBookResponse> UpdateAsync(int id, UpdateBookRequest request);
    }
}
