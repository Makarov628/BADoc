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
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetContactDTO>>> Get()
        {
            try
            {
                return Ok(await _contactService.GetAll());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ErrorDTO.Create(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetContactDTO>> GetContact(Guid id)
        {
            try
            {
                return Ok(await _contactService.Get(id));
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactDTO contactDTO)
        {
            try
            {
                await _contactService.Create(contactDTO);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ErrorDTO.Create(ex.Message));
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactDTO contactDTO)
        {
            try
            {
                await _contactService.Update(contactDTO);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ErrorDTO.Create(ex.Message));
            }

            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteNode([FromBody] DeleteContactDTO contactDTO)
        {
            try
            {
                await _contactService.Delete(contactDTO);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ErrorDTO.Create(ex.Message));
            }

            return NoContent();
        }

    }
}
