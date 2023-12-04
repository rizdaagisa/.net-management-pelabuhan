using ILCS_restfulAPI.Models;
using ILCS_restfulAPI.Models.DTO;
using ILCS_restfulAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ILCS_restfulAPI.Controllers
{
    [Route("api/barang")]
    [ApiController]
    public class BarangController : ControllerBase {
        
        private readonly BarangService barangService;

        public BarangController(BarangService barangService)
        {
            this.barangService = barangService;
        }

        [HttpGet("all")]
        public IActionResult Index() {
            return Ok(barangService.getall());
        }
        
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<BarangResponse> GetBarang(int id) {
            if (id <= 0 ) {
                return BadRequest();
            } 
            
            var response = barangService.getall().FirstOrDefault(response => response.id_barang == id);
            if (response == null) {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetKdBarang([FromQuery] int hs_code) {
            if (hs_code <= 0 ) {
                return BadRequest();
            }
            
            return Ok(barangService.getKodeBarang(hs_code));
        }
        
    }
}
