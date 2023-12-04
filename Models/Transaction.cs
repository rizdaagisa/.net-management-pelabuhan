using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILCS_restfulAPI.Models; 

public class Transaction {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Required]
    public int id_pelabuhan { get; set; }
    
    [Required]
    public int id_barang { get; set; }
    
    [Required]
    public long kd_tarif { get; set; }
    
    [Required]
    public long harga { get; set; }
    
    [ForeignKey("id_pelabuhan")]
    public Pelabuhan Pelabuhan { get; set; }
    
    [ForeignKey("kd_tarif")]
    public Tarif Tarif { get; set; }

    [ForeignKey("id_barang")]
    public Barang Barang { get; set; }
}