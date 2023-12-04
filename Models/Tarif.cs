using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILCS_restfulAPI.Models; 

public class Tarif {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long kd_tarif { get; set; }
    
    [Required]
    public double tarif_bm { get; set; }
    
    public ICollection<Transaction> Transactions { get; set; }
    
    public ICollection<Barang> Barang { get; set; }
}