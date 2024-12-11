using Bonluck.Domain.Responses;
using Mohtawa.Domain.DTOs;

namespace Mohtawa.Domain.Responses
{
    public class GetBooksResponse: BaseServiceResponse
    {
        public List<BookDTO> Data { get; set; }
    }
}
