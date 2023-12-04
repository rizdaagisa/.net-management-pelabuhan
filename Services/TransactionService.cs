using System.Transactions;
using ILCS_restfulAPI.Data;
using ILCS_restfulAPI.Models;
using ILCS_restfulAPI.Models.DTO;
using ILCS_restfulAPI.Models.DTO.pelabuhan;
using Microsoft.EntityFrameworkCore;
using Transaction = ILCS_restfulAPI.Models.Transaction;

namespace ILCS_restfulAPI.Services; 

public class TransactionService {
    
    private readonly DbSet<Transaction> repositoryTransaction;
    private readonly DbSet<Barang> repositoryBarang;
    private readonly DbSet<Tarif> repositoryTarif;
    private readonly DbSet<Pelabuhan> repositoryPelabuhan;
    
    public TransactionService(DataContext dataContext) {
        this.repositoryTransaction = dataContext.t_transactions;
        this.repositoryTarif = dataContext.m_tarif;
        this.repositoryPelabuhan = dataContext.m_pelabuhan;
        this.repositoryBarang = dataContext.m_barang;
    }

    public List<TransactionResponse> getall() {
        
        List<TransactionResponse> transactionResponses = repositoryTransaction
            .ToList()
            .Select(t => new TransactionResponse
            {
                id_transaction = t.id,
                pelabuhan = repositoryPelabuhan
                    .Where(p => p.id == t.id_pelabuhan)
                    .Select(p => new PelabuhanResponse
                    {
                        id_pelabuhan = p.id,
                        nama = p.nama,
                        id_negara = p.id_negara,
                        kd_negara = p.Negara.kd_negara, // Add null check
                    })
                    .FirstOrDefault(),
                barang = repositoryBarang
                    .Where(b => b.id == t.id_barang)
                    .Select(b => new DetailBarangResponse()
                    {
                        id_barang = b.id,
                        nama = b.nama,
                        kd_tarif = b.kd_tarif
                    })
                    .FirstOrDefault(),
                kd_tarif = repositoryTarif
                    .Where(tr => tr.kd_tarif == t.kd_tarif)
                    .Select(tr => new DetailTarifResponse()
                    {
                        kd_tarif = tr.kd_tarif,
                        tarif_bm = tr.tarif_bm,
                    })
                    .FirstOrDefault(),  
                harga = t.harga,
                total_harga_bm = (repositoryTarif.FirstOrDefault(tr => tr.kd_tarif == t.kd_tarif).tarif_bm) * t.harga 
            })
            .ToList();

        return transactionResponses;
        
        // List<Transaction> transactions = repositoryTransaction.ToList();
        // transactions.Select(t => new TransactionResponse() {
        //     id_transaction = t.id,
        //     pelabuhan = repositoryPelabuhan.Select(p => new PelabuhanResponse() {
        //         id_pelabuhan = p.id,
        //         nama = p.nama,
        //         id_negara = p.id_negara,
        //         kd_negara = p.Negara.kd_negara,
        //     }).Where(p=> p.id_pelabuhan == t.id_pelabuhan),
        //     barang = repositoryBarang.Select(b => new BarangResponse() {
        //         id_barang = b.id,
        //         nama = b.nama,
        //         kd_tarif = b.kd_tarif,
        //         tarif_bm = b.Tarif.tarif_bm
        //     }).Where(b=>b.id_barang == t.id_barang),
        //     kd_tarif = repositoryTarif.Select(tr => new TarifResponse() {
        //         kd_tarif = tr.kd_tarif,
        //         tarif_bm = tr.tarif_bm
        //     }).Where(tr=> tr.kd_tarif == t.kd_tarif)
        // }).ToList();
    }
    
    // public bool saveTransaction(TransactionRequest request) {
    //
    //     request.id_barang = getall.OrderByDescending(u => u.id_barang).FirstOrDefault().id_barang + 1;
    //     BarangResponse barang = new BarangResponse { id_barang = request.id, nama = request. };
    //     getall.Add(barang);
    //     return request;
    // }
}