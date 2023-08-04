using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace sge.Entities;
[Table("viatura")]
public class Viatura
{
  [Key]
  [Required]
  [StringLength(7)]
  [Display(Name = "Placa")]
  public string? placa {get; set;}
  [Required]
  [Display(Name = "Ordem")]
  public int ordem {get; set;}
  [Required]
  [Display(Name = "Situação")]
  public SituacaoViatura situacaoViatura {get; set;}
  public enum SituacaoViatura {Ativo, Manutencao, Devolvido, Reserva}
}
