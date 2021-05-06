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
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BADoc.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TreeViewController : ControllerBase
    {
        private readonly ITreeViewService _treeViewService;
        public TreeViewController(ITreeViewService treeViewService)
        {
            _treeViewService = treeViewService;
        }


        [HttpGet]
        public async Task<ActionResult<List<GetTreeViewDTO>>> Get([FromQuery] Guid? rootId)
        {
            try
            {
                return Ok(await _treeViewService.GetTreeView(rootId));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ErrorDTO.Create(ex.Message));
            }
        }

        [HttpGet("parents-only")]
        public async Task<ActionResult<List<GetTreeViewDTO>>> GetParentsOnly([FromQuery] Guid? rootId)
        {
            try
            {
                return Ok(await _treeViewService.GetTreeWithParentsOnly(rootId));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ErrorDTO.Create(ex.Message));
            }
        }

        [HttpPost("node")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewNode([FromBody] CreateNodeDTO nodeDTO)
        {
            try
            {
                await _treeViewService.AddNode(nodeDTO);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ErrorDTO.Create(ex.Message));
            }
        }

        [HttpPut("node")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateNode([FromBody] UpdateNodeDTO nodeDTO)
        {
            try
            {
                await _treeViewService.UpdateNode(nodeDTO);
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

        [HttpDelete("node")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteNode([FromBody] DeleteNodeDTO nodeDTO)
        {
            try
            {
                await _treeViewService.DeleteNode(nodeDTO);
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
