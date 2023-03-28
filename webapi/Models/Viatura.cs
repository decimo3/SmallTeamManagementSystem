using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mestreruan.api.Models;
[Table("viatura")]
public class Viatura
{
  [Key]
  [StringLength(7)]
  public string? placa {get; set;}
  [Required]
  public int ordem {get; set;}
  [Required]
  [MaxLength(32)]
  public string? marcaModelo {get; set;}
  [MaxLength(17)]
  public string? chassi {get; set;} // opcional
  [Required]
  public Situacao situacao {get; set;}
  public enum Situacao {Ativo, Manutencao, Devolvido, Reserva}
}
