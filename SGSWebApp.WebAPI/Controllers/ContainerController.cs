using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGSWebApp.Application.Common.DTOs;
using SGSWebApp.Application.Common.Interfaces.Repositories;
using SGSWebApp.Application.Common.Models;

namespace SGSWebApp.WebAPI.Controllers
{
    [Route("api/container")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IContainerRepository _containerRepository;

        public ContainerController(IContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<PageViewModel<ContainerDTO>>> GetAllContainers(int page = 1)
        {
            var containers = await _containerRepository.GetContainersList(page);
            return Ok(containers);
        }

        [HttpGet("get")]
        public async Task<ActionResult<ContainerDTO>> GetContainer(Guid containerId)
        {
            try
            {
                return await _containerRepository.GetContainerById(containerId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddContainer(ContainerDTO containerDTO)
        {
            await _containerRepository.AddContainer(containerDTO);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateContainer(ContainerDTO containerDTO)
        {
            try
            {
                await _containerRepository.UpdateContainer(containerDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> DeleteContainer(Guid containerId)
        {
            try
            {
                await _containerRepository.DeleteContainer(containerId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
