using ILCS_restfulAPI.Data;
using ILCS_restfulAPI.Models.DTO;

namespace ILCS_restfulAPI.Services; 

public class TransactionService {
    private readonly DataContext repositoryBarang;
    
    public TransactionService(DataContext dataContext) {
        repositoryBarang = dataContext;
    }

    public static List<BarangResponse> getall = new List<BarangResponse> {
        new BarangResponse { id_barang = 1, nama = "rokok" },
        new BarangResponse { id_barang = 2, nama = "tas" }
    };
    
    public static BarangRequest saveBarang(BarangRequest request) {


        request.id = getall.OrderByDescending(u => u.id_barang).FirstOrDefault().id_barang + 1;
        BarangResponse barang = new BarangResponse { id_barang = request.id, nama = request.nama };
        getall.Add(barang);
        return request;
    }
}