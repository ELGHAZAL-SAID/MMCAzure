using Microsoft.AspNetCore.Mvc;
using MMC.Application.Interfaces;
using MMC.Domain.Entities;

namespace MMC.API.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class SupportController : Controller
    {
        private readonly ISupportService _supportService;

        public SupportController(ISupportService supportService)
        {
            _supportService = supportService;
        }

        public ISupportService Get_supportService()
        {
            return _supportService;
        }

        [HttpGet]
        public async Task<ActionResult<PresentationSupport>> GetSupportById(int EventId)
        {

            if (await _supportService.GetSupportByIdAsync(EventId) == null)
            {
                return NotFound();
            }

            return await _supportService.GetSupportByIdAsync(EventId);
        }
        [HttpGet]

    }
}
