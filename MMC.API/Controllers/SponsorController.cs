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
<<<<<<< HEAD
            var sponsorDto = await _sponsorService.FindByIdAsync(id);

            if (sponsorDto == null)
=======
            var SponsorDto = await _sponsorService.FindByIdAsync(id);

            if (SponsorDto == null)
>>>>>>> 01c892100a06d9ca798a35ec7f8a1cabd1c02b73
            {
                return NotFound();
            }

<<<<<<< HEAD
            return Ok(sponsorDto);
=======
            return Ok(SponsorDto);
>>>>>>> 01c892100a06d9ca798a35ec7f8a1cabd1c02b73
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var SponsorDtos = await _sponsorService.FindAllAsync();
            return Ok(SponsorDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSponsorDTO addSponsorDto)
        {
            var createdSponsorDto = await _sponsorService.CreateAsync(addSponsorDto);
            return CreatedAtAction(nameof(GetById), new { id = createdSponsorDto.Id }, createdSponsorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSponsorDTO updateSponsorDto)
        {
            var updatedSponsorDto = await _sponsorService.UpdateAsync(id, updateSponsorDto);

            if (updatedSponsorDto == null)
            {
                return NotFound();
            }

            return Ok(updatedSponsorDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sponsorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
