using BookManagement.Models.Dtos;
using BookManagement.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [Route("books")]
    [ApiController]
    public class BooksController(IUnitOfWork unitOfWork) : ControllerBase
    {
        /// <summary>
        /// Get multiple books order by it's popularity.
        /// </summary>
        /// <param name="pageNumber">Page number,by default: 1</param>
        /// <param name="pageSize">Page size, by deafult: 10</param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public async Task<IActionResult> GetPopularBooks([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var result = await unitOfWork.BookService.GetPopularBooks(pageNumber, pageSize);
            return Ok(result);
        }

        /// <summary>
        /// Get book details.
        /// </summary>
        /// <param name="id">Book id</param>
        /// <returns>IActionResult</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBookDetails([FromRoute] Guid id)
        {
            var result = await unitOfWork.BookService.GetBookDetails(id);
            return Ok(result);
        }

        /// <summary>
        /// Add single book.
        /// </summary>
        /// <param name="model">Book model</param>
        /// <returns>IActionResult</returns>
        [HttpPost("add/single")]
        public async Task<IActionResult> AddSingleBook([FromForm] BookForCreatingDto model)
        {
            var result = await unitOfWork.BookService.AddSingleBook(model);
            await unitOfWork.Save();

            return Ok(result);
        }


        /// <summary>
        /// Delete single book.
        /// </summary>
        /// <param name="id">Book id</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("delete/single/{id:guid}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
            var result = await unitOfWork.BookService.DeleteSingleBook(id);
            await unitOfWork.Save();

            return Ok(result);
        }
    }
}
