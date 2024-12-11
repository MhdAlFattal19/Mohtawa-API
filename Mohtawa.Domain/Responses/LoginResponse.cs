using Bonluck.Domain.Responses;
using Mohtawa.Domain.DTOs;

namespace Mohtawa.Domain.Responses
{
    public class LoginResponse : BaseServiceResponse
    {
        public LoginDTO Data { get; set; }

    }
}