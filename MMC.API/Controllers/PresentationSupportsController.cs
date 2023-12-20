using Microsoft.AspNetCore.Mvc;
using MMC.Application.DTOs.PartnerDTOs;
using MMC.Application.DTOs.SupportDTOs;
using MMC.Application.Interfaces;
using MMC.Application.Services;
using MMC.Domain.Entities;
using System;



namespace MMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentationSupportsController : ControllerBase
    {

        private readonly ISupportService _presentationSupportService;

        public PresentationSupportsController(ISupportService presentationSupportService)
        {
            _presentationSupportService = presentationSupportService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var presentationSupportService = await _presentationSupportService.FindByIdAsync(id);

            if (presentationSupportService == null)
            {
                return NotFound();
            }

            return Ok(presentationSupportService);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var presentationSupportService = await _presentationSupportService.FindAllAsync();
            return Ok(presentationSupportService);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSupportDTO addSupportDto)
        {
            var createdSupportDto = await _presentationSupportService.CreateAsync(addSupportDto);
            return CreatedAtAction(nameof(GetById), new { id = createdSupportDto.Id }, createdSupportDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSupportDTO updateSupportDto)
        {
            var updatedSDto = await _presentationSupportService.UpdateAsync(id, updateSupportDto);

            if (updatedSDto == null)
            {
                return NotFound();
            }

            return Ok(updatedSDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _presentationSupportService.DeleteAsync(id);
            return NoContent();
        }
    }

}

