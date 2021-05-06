using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using BADoc.UseCases.Interfaces;
using BADoc.UseCases.DTO;
using BADoc.UseCases.Exceptions;
using BADoc.Web.DTO;
using Microsoft.AspNetCore.Authorization;

namespace BADoc.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PageController : ControllerBase
    {
        private readonly IPageService _pageService;
        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPageDTO>> Get(Guid id)
        {
            try
            {
                return Ok(await _pageService.Get(id));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ErrorDTO.Create(ex.Message));
            }

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateNode([FromBody] UpdatePageDTO pageDTO)
        {
            try
            {
                await _pageService.Update(pageDTO);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ErrorDTO.Create(ex.Message));
            }

        }



    }
}
