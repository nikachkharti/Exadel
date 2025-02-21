using BookManagement.Models.Dtos.Book;
using BookManagement.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
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
            var response = new EndpointResponse(EndpointResponseMessage.SuccessMessage, isSuccess: true, result, 200);

            return StatusCode(response.StatusCode, response);
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
            await unitOfWork.Save();//Saves view increment operation

            var response = new EndpointResponse(EndpointResponseMessage.SuccessMessage, isSuccess: true, result, 200);

            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Add single book.
        /// </summary>
        /// <param name="model">Book model</param>
        /// <returns>IActionResult</returns>
        [HttpPost("add/single")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSingleBook([FromForm] BookForCreatingDto model)
        {
            var result = await unitOfWork.BookService.AddSingleBook(model);
            await unitOfWork.Save();

            var response = new EndpointResponse(EndpointResponseMessage.SuccessMessage, isSuccess: true, result, 201);
            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Add multiple books.
        /// </summary>
        /// <param name="model">Hashset of book models</param>
        /// <returns>IActionResult</returns>
        [HttpPost("add/multiple")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddMultipleBooks([FromBody] HashSet<BookForCreatingDto> model)
        {
            var result = await unitOfWork.BookService.AddMultipleBooks(model);
            await unitOfWork.Save();

            var response = new EndpointResponse(EndpointResponseMessage.SuccessMessage, isSuccess: true, result, 201);
            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Delete single book.
        /// </summary>
        /// <param name="id">Book id</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("delete/single/{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSingleBook([FromRoute] Guid id)
        {
            var result = await unitOfWork.BookService.DeleteSingleBook(id);
            await unitOfWork.Save();

            var response = new EndpointResponse(EndpointResponseMessage.SuccessMessage, isSuccess: true, result, 204);
            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Delete multiple books.
        /// </summary>
        /// <param name="ids">Argument</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("delete/multiple")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMultipleBooks([FromBody] HashSet<Guid> ids)
        {
            var result = await unitOfWork.BookService.DeleteMultipleBooks(ids);
            await unitOfWork.Save();

            var response = new EndpointResponse(EndpointResponseMessage.SuccessMessage, isSuccess: true, result, 204);
            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Update single book.
        /// </summary>
        /// <param name="model">Update model</param>
        /// <returns>IActionResult</returns>
        [HttpPut("update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateSingleBook([FromForm] BookForUpdatingDto model)
        {
            var result = await unitOfWork.BookService.UpdateSingleBook(model);
            await unitOfWork.Save();

            var response = new EndpointResponse(EndpointResponseMessage.SuccessMessage, isSuccess: true, result, 200);
            return StatusCode(response.StatusCode, response);
        }
    }
}
