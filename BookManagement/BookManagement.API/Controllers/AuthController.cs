using Azure;
using BookManagement.Models.Dtos.Identity;
using BookManagement.Service.Contracts;
using BookManagement.Service.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookManagement.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        /// <summary>
        /// User registration.
        /// </summary>
        /// <param name="model">RegistrationRequestDto</param>
        /// <returns>IActionResult</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegistrationRequestDto model)
        {
            await authService.Register(model);
            var response = new EndpointResponse(EndpointResponseMessage.SuccessMessage, isSuccess: true, model, 201);

            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Admin registration.
        /// </summary>
        /// <param name="model">RegistrationRequestDto</param>
        /// <returns>IActionResult</returns>
        [HttpPost("registeradmin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin([FromForm] RegistrationRequestDto model)
        {
            await authService.RegisterAdmin(model);
            var response = new EndpointResponse(EndpointResponseMessage.SuccessMessage, isSuccess: true, model, 201);

            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Login.
        /// </summary>
        /// <remarks>
        ///     ADMIN ROLE USER AND PASSWORD: [ admin@gmail.com  Admin123! ]
        ///     CUSTOMER ROLE USER AND PASSWORD: [ nika@gmail.com  Nika123! ]
        /// </remarks>
        /// <param name="model">LoginRequestDto</param>
        /// <returns>IActionResult</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestDto model)
        {
            var loginResponse = await authService.Login(model);
            var response = new EndpointResponse(EndpointResponseMessage.SuccessMessage, isSuccess: true, loginResponse, 200);

            return StatusCode(response.StatusCode, response);
        }
    }
}
