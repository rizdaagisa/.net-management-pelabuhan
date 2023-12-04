using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using ILCS_restfulAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILCS_restfulAPI.Controllers; 

[Route("api/tarif")]
[ApiController]
public class TarifController : ControllerBase{
    private readonly TarifService tarifService;

    public TarifController(TarifService tarifServices) {
        this.tarifService = tarifServices;
    } 
    
    [HttpGet("all")]
    public IActionResult Index() {
        return Ok(tarifService.getall());
    }
        
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public IActionResult getTarif([FromQuery, Required] long hs_code, [FromQuery, Optional] long harga) {
        if (hs_code <= 0 || hs_code == null ) {
            return BadRequest();
        }
        var response = tarifService.getByName(hs_code, harga);
        if (response == null) {
            return NotFound();
        }
        return Ok(response);
    }
}