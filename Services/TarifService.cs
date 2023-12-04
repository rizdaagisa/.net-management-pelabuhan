using ILCS_restfulAPI.Data;
using ILCS_restfulAPI.Models;
using ILCS_restfulAPI.Models.DTO;
using ILCS_restfulAPI.Models.DTO.negara;
using ILCS_restfulAPI.Models.DTO.pelabuhan;
using Microsoft.EntityFrameworkCore;

namespace ILCS_restfulAPI.Services; 

public class TarifService {
    
    private readonly DbSet<Tarif> repositoryTarif;
    private readonly DbSet<Barang> repositoryBarang;
    
    public TarifService(DataContext dataContext) {
        this.repositoryTarif = dataContext.m_tarif;
        this.repositoryBarang = dataContext.m_barang;
    }

    public List<TarifResponse> getall() {
        var dataResponse = repositoryTarif
            .Select(tarif => new TarifResponse(){
                kd_tarif = tarif.kd_tarif,
                tarif_bm = tarif.tarif_bm,
                list_barang = repositoryBarang.Select(barang => new DetailBarangResponse() { 
                    id_barang = barang.id,
                    nama = barang.nama,
                    kd_tarif = barang.kd_tarif
                }).Where(p => p.kd_tarif == tarif.kd_tarif).ToList() 
            }).ToList();
        
        return dataResponse;
    }

    public object getByName(long kd_tarif, long harga) {
        
        var tarif = repositoryTarif.FirstOrDefault(n => n.kd_tarif == kd_tarif);
    
        if (tarif == null) { //jika tidak ada didatabase maka return null
            return null;
        }

        if (harga != null) {
            var response = new HargaTarifResponse() {
                kd_tarif = tarif.kd_tarif,
                tarif_bm = tarif.tarif_bm,
                total_tarif_bm = tarif.tarif_bm * harga
            };
            return response;
        } else {
            var response = new DetailTarifResponse() {
                kd_tarif = tarif.kd_tarif,
                tarif_bm= tarif.tarif_bm
            };
            return response;
        }
    }
}