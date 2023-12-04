namespace ILCS_restfulAPI.Models.DTO.pelabuhan; 

public class PelabuhanResponse {
    public int id_pelabuhan { get; set; }
    
    public int ?id_negara { get; set; }
    
    public string kd_negara { get; set; }
    
    public string nama { get; set; }
}