using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMC.Application.DTOs.SponsorDTOs;
using MMC.Application.Interfaces;


namespace MMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        public readonly ISponsorService _sponsorService;

        public SponsorController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var SponsorDto = await _sponsorService.FindByIdAsync(id);

            if (SponsorDto == null)
            {
                return NotFound();
            }

            return Ok(SponsorDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var SponsorDtos = await _sponsorService.FindAllAsync();
            return Ok(SponsorDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSponsorDTO addPartnerDto)
        {
            var createdSponsorDto = await _sponsorService.CreateAsync(addPartnerDto);
            return CreatedAtAction(nameof(GetById), new { id = createdSponsorDto.Id }, createdSponsorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSponsorDTO updateSponsorDto)
        {
            var updatedPartnerDto = await _sponsorService.UpdateAsync(id, updateSponsorDto);

            if (updatedPartnerDto == null)
            {
                return NotFound();
            }

            return Ok(updatedPartnerDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sponsorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
