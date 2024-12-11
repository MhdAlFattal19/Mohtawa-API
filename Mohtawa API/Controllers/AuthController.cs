using Azure;
using Bonluck.Domain.Responses;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Mohtawa.Domain.Contracts;
using Mohtawa.Domain.DTOs;
using Mohtawa.Domain.Requests;
using Mohtawa.Domain.Responses;
using Newtonsoft.Json;
using LoginRequest = Mohtawa.Domain.Requests.LoginRequest;

namespace Mohtawa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthService _authService;

        public AuthController(IBookService bookService, IAuthService authService)
        {
            _bookService = bookService;
            _authService = authService;
        }

        [HttpPost(nameof(Login))]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            var response = await _authService.Login(request);
            return StatusCode(response.StatusCode, response);
        }


    }
}