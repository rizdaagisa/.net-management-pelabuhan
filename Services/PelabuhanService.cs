using ILCS_restfulAPI.Data;
using ILCS_restfulAPI.Models;
using ILCS_restfulAPI.Models.DTO.negara;
using ILCS_restfulAPI.Models.DTO.pelabuhan;
using Microsoft.EntityFrameworkCore;

namespace ILCS_restfulAPI.Services; 

public class PelabuhanService {
    
    private readonly DbSet<Negara> repositoryNegara;
    private readonly DbSet<Pelabuhan> repositoryPelabuhan;
    
    public PelabuhanService(DataContext dataContext) {
        this.repositoryNegara = dataContext.m_negara;
        this.repositoryPelabuhan = dataContext.m_pelabuhan;
    }

    public List<PelabuhanResponse> getall() {
        var dataResponse = repositoryPelabuhan
            .Select(pelabuhan => new PelabuhanResponse()
        {
            id_pelabuhan = pelabuhan.id,
            id_negara = repositoryPelabuhan.FirstOrDefault(negara => negara.id_negara == pelabuhan.id_negara).id_negara,
            kd_negara = repositoryPelabuhan.FirstOrDefault(negara => negara.Negara.kd_negara == pelabuhan.Negara.kd_negara).Negara.kd_negara,
            nama = pelabuhan.nama,
        }).ToList();
        
        return dataResponse;
    }

    public PelabuhanResponse getByName(string nama, string kd_negara) {
        
        var negara = repositoryNegara.FirstOrDefault(n => n.kd_negara.ToLower() == kd_negara.ToLower());

        if (negara == null) {
            return null;
        }

        var pelabuhan = repositoryPelabuhan
            .FirstOrDefault(p => p.id_negara == negara.id && p.nama.ToLower().Contains(nama.ToLower()));

        if (pelabuhan != null) {
            var response = new PelabuhanResponse {
                id_pelabuhan = pelabuhan.id,
                id_negara = pelabuhan.id_negara,
                kd_negara = pelabuhan.Negara.kd_negara,
                nama = pelabuhan.nama,
            };
            return response;
        }
        else {
            return null;
        }
    }
}