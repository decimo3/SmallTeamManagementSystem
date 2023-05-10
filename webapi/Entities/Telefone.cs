using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mestreruan.api.Entities;
[Table("telefone")]
public class Telefone
{
  [Key]
  public long numero {get; set;}
  [Required]
  public string? chip {get; set;}
  [Required]
  public long imei {get; set;}
  [Required]
  [MaxLength(16)]
  public string? marca {get; set;}
  [Required]
  [MaxLength(16)]
  public string? modelo {get; set;}
  public SituacaoTelefone situacaoTelefone {get; set;}
  public enum SituacaoTelefone {Ativo, Manutencao, Devolvido, Reserva}
}
