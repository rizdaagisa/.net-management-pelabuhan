using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ILCS_restfulAPI.Models; 

public class Negara {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Required]
    public string kd_negara { get; set; }
       
    [Required]
    public string nama  { get; set; }
    
    public ICollection<Pelabuhan> Pelabuhan { get; set; }
}