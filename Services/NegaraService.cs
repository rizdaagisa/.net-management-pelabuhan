using ILCS_restfulAPI.Data;
using ILCS_restfulAPI.Models;
using ILCS_restfulAPI.Models.DTO;
using ILCS_restfulAPI.Models.DTO.negara;
using Microsoft.EntityFrameworkCore;

namespace ILCS_restfulAPI.Services; 

public class NegaraService {
    private readonly DbSet<Negara> repositoryNegara;
    private readonly DbSet<Pelabuhan> repositoryPelabuhan;
    
    public NegaraService(DataContext dataContext) {
        this.repositoryNegara = dataContext.m_negara;
        this.repositoryPelabuhan = dataContext.m_pelabuhan;
    }

    public List<NegaraResponse> getall() {
        var dataResponse = repositoryNegara.ToList();
        var negaraResponses = dataResponse.Select(negara => new NegaraResponse
        {
            id = negara.id,
            kd_negara = negara.kd_negara,
            nama = negara.nama
        }).ToList();
        return negaraResponses;
    }

    public NegaraResponse getByName(string nama) {
        var data = repositoryNegara.FirstOrDefault(response => response.nama.ToLower().Contains(nama.ToLower()));
        
        return new NegaraResponse {
            id = data.id,
            kd_negara = data.kd_negara,
            nama = data.nama
        };
    }
}