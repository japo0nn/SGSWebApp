using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGSWebApp.Application.Common.DTOs;
using SGSWebApp.Application.Common.Interfaces.Repositories;
using SGSWebApp.Application.Common.Models;
using SGSWebApp.Infrastructure.Repositories;

namespace SGSWebApp.WebAPI.Controllers
{
    [Route("api/operation")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationRepository _operationRepository;
        public OperationController(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<PageViewModel<ContainerDTO>>> GetAllOperations(int page = 1)
        {
            var containers = await _operationRepository.GetOperationsList(page);
            return Ok(containers);
        }

        [HttpGet("get-by-containerId")]
        public async Task<ActionResult<PageViewModel<OperationDTO>>> GetOperationsByContainerId(Guid containerId, int page = 1)
        {
            try
            {
                return await _operationRepository.GetOperationsByContainerId(containerId, page);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOperation(OperationDTO operationDTO)
        {
            await _operationRepository.AddOperation(operationDTO);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateOpertaion(OperationDTO operationDTO)
        {
            try
            {
                await _operationRepository.UpdateOperation(operationDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> DeleteOperation(Guid operationId)
        {
            try
            {
                await _operationRepository.DeleteOperation(operationId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
