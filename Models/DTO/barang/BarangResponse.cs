using Microsoft.Build.Framework;

namespace ILCS_restfulAPI.Models.DTO; 

public class BarangResponse {
    public int id_barang { get; set; }
    public string nama { get; set; }
    
    public long kd_tarif { get; set; }
    
    public double tarif_bm { get; set; }
    // public DateTime createdDate { get; set; }
}