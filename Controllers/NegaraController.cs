using ILCS_restfulAPI.Models;
using ILCS_restfulAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILCS_restfulAPI.Controllers; 

[Route("api/negara")]
[ApiController]
public class NegaraController : ControllerBase {
       
    private readonly NegaraService negaraService;

    public NegaraController(NegaraService negaraService)
    {
        this.negaraService = negaraService;
    }
    
    [HttpGet("all")]
    public IActionResult Index() {
        return Ok(negaraService.getall());
    }
        
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public ActionResult<Negara> GetBarang([FromQuery] string negara) {
        if (negara == "" || negara == null ) {
            return BadRequest();
        }
        var response = negaraService.getByName(negara);
        if (response == null) {
            return NotFound();
        }
        return Ok(response);
    }

    // [HttpGet]
    // [ProducesResponseType(200)]
    // [ProducesResponseType(404)]
    // [ProducesResponseType(400)]
    // public IActionResult GetKdBarang([FromQuery] int hs_code) {
    //     if (hs_code <= 0 ) {
    //         return BadRequest();
    //     }
    //
    //     return null;
    //     // return Ok(negaraService.getKodeBarang(hs_code));
    // }
    
}