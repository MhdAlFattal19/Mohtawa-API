using Bonluck.Domain.Responses;
using Mohtawa.Domain.DTOs;

namespace Mohtawa.Domain.Responses
{
    public class GetBookResponse: BaseServiceResponse
    {
        public BookDTO Data { get; set; }

    }
}
