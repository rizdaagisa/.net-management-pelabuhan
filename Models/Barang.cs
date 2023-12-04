using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILCS_restfulAPI.Models; 

public class Barang {
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Required]
    public long kd_tarif { get; set; }
    
    [Required]
    public string nama { get; set; }
    
    [ForeignKey("kd_tarif")]
    public Tarif Tarif { get; set; }
    
    public ICollection<Transaction> Transactions { get; set; }
}