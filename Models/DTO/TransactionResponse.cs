using ILCS_restfulAPI.Models.DTO.pelabuhan;

namespace ILCS_restfulAPI.Models.DTO; 

public class TransactionResponse {
    
    public int id_transaction { get; set; }
    
    public PelabuhanResponse pelabuhan { get; set; }
    
    public DetailBarangResponse barang { get; set; }
    
    public DetailTarifResponse kd_tarif { get; set; }
    
    public long harga { get; set; }
    public double total_harga_bm { get; set; }
}