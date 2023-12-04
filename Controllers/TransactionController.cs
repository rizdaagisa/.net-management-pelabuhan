using ILCS_restfulAPI.Models.DTO;
using ILCS_restfulAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILCS_restfulAPI.Controllers; 

[Route("api/transaction")]
[ApiController]
public class TransactionController : ControllerBase{
    private readonly TransactionService transactionService;

    public TransactionController(TransactionService transactionServices) {
        this.transactionService = transactionServices;
    } 
    
    [HttpGet("all")]
    public IActionResult Index() {
        return Ok(transactionService.getall());
    }
        
    // [HttpPost]
    // [ProducesResponseType(200)]
    // [ProducesResponseType(404)]
    // [ProducesResponseType(400)]
    // public IActionResult GetBarang([FromQuery] TransactionRequest request) {
    //     if (request == null ) {
    //         return BadRequest();
    //     }
    //     var response = transactionService.saveTransaction(request);
    //     if (!response) {
    //         return NotFound();
    //     }
    //     return Ok(request);
    // }
}