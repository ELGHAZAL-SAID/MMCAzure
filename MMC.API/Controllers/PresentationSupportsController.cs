﻿using System;

public class PresentationSupportsController : ControllerBase
{
    private readonly IPresentationSupportService _presentationSupportService;

    public PresentationSupportsController(IPresentationSupportService presentationSupportService)
    {
        _presentationSupportService = presentationSupportService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PresentationSupport>> GetPresentationSupportById(int id)
    {
        var presentationSupport = await _presentationSupportService.GetPresentationSupportByIdAsync(id);

        if (presentationSupport == null)
        {
            return NotFound();
        }

        return presentationSupport;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PresentationSupport>>> GetPresentationSupportsByEventId(int eventId)
    {
        return await _presentationSupportService.GetPresentationSupportsByEventIdAsync(eventId);
    }

    [HttpPost]
    public async Task<ActionResult<PresentationSupport>> CreatePresentationSupport(PresentationSupport presentationSupport)
    {
        await _presentationSupportService.CreatePresentationSupportAsync(presentationSupport);

        return CreatedAtAction("GetPresentationSupportById", new { id = presentationSupport.Id }, presentationSupport);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePresentationSupport(int id, PresentationSupport presentationSupport)
    {
        if (id != presentationSupport.Id)
        {
            return BadRequest();
        }

        await _presentationSupportService.UpdatePresentationSupportAsync(presentationSupport);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePresentationSupport(int id)
    {
        await _presentationSupportService.DeletePresentationSupportAsync(id);

        return NoContent();
    }
}
