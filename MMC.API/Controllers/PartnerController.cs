using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMC.Application.DTOs.PartnerDTOs;
using MMC.Application.Interfaces;

namespace MMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var partnerDto = await _partnerService.FindByIdAsync(id);

            if (partnerDto == null)
            {
                return NotFound();
            }

            return Ok(partnerDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var partnerDtos = await _partnerService.FindAllAsync();
            return Ok(partnerDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPartnerDTO addPartnerDto)
        {
            var createdPartnerDto = await _partnerService.CreateAsync(addPartnerDto);
            return CreatedAtAction(nameof(GetById), new { id = createdPartnerDto.Id }, createdPartnerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePartnerDTO updatePartnerDto)
        {
            var updatedPartnerDto = await _partnerService.UpdateAsync(id, updatePartnerDto);

            if (updatedPartnerDto == null)
            {
                return NotFound();
            }

            return Ok(updatedPartnerDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _partnerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
