using Company.ProjectName.Application.DTO;
using Company.ProjectName.Application.Interface;
using Company.ProjectName.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Company.ProjectName.Services.WebApi.Controllers.v2
{
    [Authorize]
    [EnableRateLimiting("fixedWindow")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesApplication _categoriesApplication;
        public CategoriesController(ICategoriesApplication categoriesApplication)
        {
            _categoriesApplication = categoriesApplication;
        }

        [HttpGet("GetAllAsync")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK,Type= typeof(Response<IEnumerable<CategoriesDto>>))]
        public async Task<IActionResult> GetAllAsync()
        {

            var response = await _categoriesApplication.GetAllAsync();

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);

        }

    }
}
