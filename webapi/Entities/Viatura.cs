using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mestreruan.api.Entities;
[Table("viatura")]
public class Viatura
{
  [Key]
  [StringLength(7)]
  public string? placa {get; set;}
  [Required]
  public int ordem {get; set;}
  [Required]
  public SituacaoViatura situacaoViatura {get; set;}
  public enum SituacaoViatura {Ativo, Manutencao, Devolvido, Reserva}
}
