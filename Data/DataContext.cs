using ILCS_restfulAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ILCS_restfulAPI.Data; 

public class DataContext : DbContext{
    protected DataContext() {
    }

    public DataContext(DbContextOptions options) : base(options) {
    }
    
    public DbSet<Barang> m_barang { get; set; }
    public DbSet<Negara> m_negara { get; set; }
    public DbSet<Pelabuhan> m_pelabuhan { get; set; }
    public DbSet<Tarif> m_tarif { get; set; }
    public DbSet<Transaction> t_transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)  {
        modelBuilder.Entity<Negara>().HasData(
            new Negara() {
                id = 1,
                kd_negara = "ID",
                nama = "Indonesia"
            },new Negara() {
                id = 2,
                kd_negara = "SG",
                nama = "Singapore"
            },new Negara() {
                id = 3,
                kd_negara = "IR",
                nama = "Iraq"
            },new Negara() {
                id = 4,
                kd_negara = "MY",
                nama = "Malaysia"
            },new Negara() {
                id = 5,
                kd_negara = "PH",
                nama = "Philippines"
            }
            );

        modelBuilder.Entity<Pelabuhan>().HasData(
            new Pelabuhan() {
                id = 111,
                id_negara = 2,
                nama = "Jurong",
            },
            new Pelabuhan() {
                id = 112,
                id_negara = 2,
                nama = "Marina",
            },
            new Pelabuhan() {
                id = 113,
                id_negara = 2,
                nama = "Keppel",
            },
            new Pelabuhan() {
                id = 114,
                id_negara = 1,
                nama = "Merak",
            },
            new Pelabuhan() {
                id = 115,
                id_negara = 1,
                nama = "Batam",
            },
            new Pelabuhan() {
                id = 116,
                id_negara = 3,
                nama = "Klang",
            },
            new Pelabuhan() {
                id = 117,
                id_negara = 4,
                nama = "Flous",
            },
            new Pelabuhan() {
                id = 118,
                id_negara = 5,
                nama = "Rafles",
            }
        );
        modelBuilder.Entity<Barang>().HasData(
            new Barang() {
                id = 555,
                kd_tarif = 10079000,
                nama = "Butiran sorghum"
            },
            new Barang() {
                id = 556,
                kd_tarif = 10079000,
                nama = "Tembakau"
            },
            new Barang() {
                id = 557,
                kd_tarif = 10079000,
                nama = "Cengkeh"
            },
            new Barang() {
                id = 558,
                kd_tarif = 10079111,
                nama = "handphone"
            },
            new Barang() {
                id = 559,
                kd_tarif = 10079111,
                nama = "Laptop"
            }
        );
        
        modelBuilder.Entity<Tarif>().HasData(
            new Tarif() {
                kd_tarif = 10079000,
                tarif_bm = 0.1D
            },
            new Tarif() {
                kd_tarif = 10079111,
                tarif_bm = 0.2D
            }
        );

        modelBuilder.Entity<Transaction>().HasData(
            new Transaction {
                id = 1,
                id_pelabuhan = 111,
                id_barang = 555,
                kd_tarif = 10079000,
                harga = 1000000
            },
            new Transaction {
                id = 2,
                id_pelabuhan = 112,
                id_barang = 556,
                kd_tarif = 10079000,
                harga = 1200000
            },
            new Transaction {
                id = 3,
                id_pelabuhan = 113,
                id_barang = 557,
                kd_tarif = 10079000,
                harga = 1300000
            },
            new Transaction {
                id = 4,
                id_pelabuhan = 114,
                id_barang = 558,
                kd_tarif = 10079111,
                harga = 1400000
            },
            new Transaction {
                id = 5,
                id_pelabuhan = 115,
                id_barang = 559,
                kd_tarif = 10079111,
                harga = 1500000
            }
            );
        
        base.OnModelCreating(modelBuilder);
    }
}