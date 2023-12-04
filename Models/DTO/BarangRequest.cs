using System.ComponentModel.DataAnnotations;

namespace ILCS_restfulAPI.Models.DTO; 

public class BarangRequest {
    
    [Required]
    public int id { get; set; }
    
    [MaxLength(30)]
    public string nama { get; set; }
    
}