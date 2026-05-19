using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDCW07.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturers
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    
    [MaxLength(300)]
    public string FullName { get; set; } = string.Empty;
    
    [Column(TypeName = "date")]
    public DateOnly FoundationDate { get; set; }
    
    
    public IEnumerable<Components> Components { get; set; } = [];
}