using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mestreruan.api.Models;
[Table("telefone")]
public class Telefone
{
  [Key]
  public int numero {get; set;}
  [Required]
  public string? chip {get; set;}
  [Required]
  public int imei {get; set;}
  [Required]
  [MaxLength(16)]
  public string? marca {get; set;}
  [Required]
  [MaxLength(16)]
  public string? modelo {get; set;}
}
