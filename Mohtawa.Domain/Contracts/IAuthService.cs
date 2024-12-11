using Mohtawa.Domain.Requests;
using Mohtawa.Domain.Responses;

namespace Mohtawa.Domain.Contracts
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}