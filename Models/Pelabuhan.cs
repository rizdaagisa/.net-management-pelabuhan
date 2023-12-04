using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILCS_restfulAPI.Models; 

public class Pelabuhan {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Required]
    public int id_negara { get; set; }

    [Required]
    public string nama { get; set; }
    
    public ICollection<Transaction> Transactions { get; set; }
    
    [ForeignKey("id_negara")]
    public Negara Negara { get; set; }
    
}