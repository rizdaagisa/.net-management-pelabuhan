using Microsoft.Build.Framework;

namespace ILCS_restfulAPI.Models.DTO; 

public class TransactionRequest {
    [Required]
    public int id_pelabuhan { get; set; }
    
    [Required]
    public int id_barang { get; set; }
    
    [Required]
    public long kd_tarif { get; set; }
    
    [Required]
    public long harga { get; set; }
}