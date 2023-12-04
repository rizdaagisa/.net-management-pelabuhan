using ILCS_restfulAPI.Data;
using ILCS_restfulAPI.Models;
using ILCS_restfulAPI.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ILCS_restfulAPI.Services; 

public class BarangService {

    private readonly DbSet<Barang> repositoryBarang;
    private readonly DbSet<Tarif> repositoryTarif;
    
    public BarangService(DataContext dataContext) {
        repositoryBarang = dataContext.m_barang;
        repositoryTarif = dataContext.m_tarif;
    }

    public List<BarangResponse> getall() {
        var dataResponse = repositoryBarang
            .Select(barang => new BarangResponse
            {
                id_barang = barang.id,
                kd_tarif = repositoryTarif.FirstOrDefault(t => t.kd_tarif == barang.kd_tarif).kd_tarif,
                nama = barang.nama,
                tarif_bm = repositoryTarif.FirstOrDefault(t => t.kd_tarif == barang.kd_tarif).tarif_bm
            })
            .ToList();
        
        return dataResponse;
    }

    public BarangResponse getById(int id) {
        var data = repositoryBarang.FirstOrDefault(response => response.id == id);
        
        return new BarangResponse() {
            id_barang = data.id,
            nama = data.nama,
            kd_tarif = data.kd_tarif
        };
    }
    
    public List<BarangResponse> getKodeBarang(int id) {
        
        var dataResponse = repositoryBarang
            .Where(barang => repositoryTarif.Any(t => t.kd_tarif == barang.kd_tarif && t.kd_tarif == id))
            .Select(barang => new BarangResponse
            {
                id_barang = barang.id,
                kd_tarif = barang.kd_tarif,
                nama = barang.nama,
                tarif_bm = repositoryTarif.FirstOrDefault(t => t.kd_tarif == barang.kd_tarif).tarif_bm
            })
            .ToList();
        
        return dataResponse;
    }

}