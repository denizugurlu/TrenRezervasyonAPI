using Microsoft.AspNetCore.Mvc;
using TrenRezervasyonu.Core.DTOs;
using TrenRezervasyonu.Services;

namespace TrenRezervasyonu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervasyonController : ControllerBase
    {
        private readonly RezervasyonService _rezervasyonService;

        public RezervasyonController(RezervasyonService rezervasyonService)
        {
            _rezervasyonService = rezervasyonService;
        }

        [HttpPost]
        public IActionResult RezervasyonYap ([FromBody] RezervasyonRequest rezervasyonRequest)
        {
                if (rezervasyonRequest == null)
            {
                return BadRequest("İstek bulunamadı. Geçersiz istek.");
            }

                var sonuc = _rezervasyonService.RezervasyonOlustur(rezervasyonRequest);
                return Ok(sonuc);

        }

    }
}
