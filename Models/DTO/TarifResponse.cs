namespace ILCS_restfulAPI.Models.DTO; 

public class TarifResponse {
    
    public long kd_tarif { get; set; }
    public double tarif_bm { get; set; }
    public ICollection<DetailBarangResponse> list_barang { get; set; } 
    
}