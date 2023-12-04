using ILCS_restfulAPI.Models;
using ILCS_restfulAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILCS_restfulAPI.Controllers; 

[Route("api/pelabuhan")]
[ApiController]
public class PelabuhanController : ControllerBase {
    private readonly PelabuhanService pelabuhanService;

    public PelabuhanController(PelabuhanService pelabuhanServices)
    {
        this.pelabuhanService = pelabuhanServices;
    }
    
    [HttpGet("all")]
    public IActionResult Index() {
        return Ok(pelabuhanService.getall());
    }
        
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public IActionResult GetBarang([FromQuery] string pelabuhan, [FromQuery] string kd_negara) {
        if (pelabuhan == "" || pelabuhan == null ) {
            return BadRequest();
        }
        var response = pelabuhanService.getByName(pelabuhan, kd_negara);
        if (response == null) {
            return NotFound();
        }
        return Ok(response);
    }
}