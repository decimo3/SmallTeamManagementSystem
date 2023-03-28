using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mestreruan.api.Models;
[Table("equipe")]
public class Equipe
{
  [Required]
  [Range(1,70)]
  public int espelho {get; set;}
  [Required]
  public Servico servico {get; set;}
  [Required]
  public DateOnly dia {get; set;}
  [Required]
  [ForeignKey("Funcionario")]
  public int supervisorId {get; set;}
  public Funcionario supervisor {get; set;}
  [Required]
  [ForeignKey("Funcionario")]
  public int motoristaId {get; set;}
  public Funcionario motorista {get; set;}
  [Required]
  [ForeignKey("Funcionario")]
  public int ajudanteId {get; set;}
  public Funcionario ajudante {get; set;}
  [Required]
  [ForeignKey("Viatura")]
  public string? viaturaId {get; set;}
  public Viatura viatura {get; set;}
  public enum Servico {Corte, Religa, PQMT, Negociacao, Inspecao, Cadastro}
}
