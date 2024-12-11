using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mohtawa.Domain.Contracts;
using Mohtawa.Domain.Requests;
using Mohtawa.Domain.Responses;

namespace Mohtawa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetBooksResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetListAsync()
        {
            var response = await _bookService.GetListAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetBookResponse), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAsync(int id)
        {
            var response = await _bookService.GetAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddBookResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddAsync([FromBody] AddBookRequest request)
        {
            var response = await _bookService.AddAsync(request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateBookResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(int id, UpdateBookRequest request)
        {
            var response = await _bookService.UpdateAsync(id, request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DeleteBookResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(int id, DeleteBookRequest request)
        {
            var response = await _bookService.DeleteAsync(id, request);
            return StatusCode(response.StatusCode, response);
        }
    }
}