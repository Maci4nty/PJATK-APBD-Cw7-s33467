using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBDCW07.Models;

[Table("PCComponents"), PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponents
{
    public int PCId { get; set; }
    
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = string.Empty;
    public int Amount { get; set; }

    [ForeignKey(nameof(PCId))]
    public PCs PC { get; set; } = null!;
    
    [ForeignKey(nameof(ComponentCode))]
    public Components Component { get; set; } = null!;
}