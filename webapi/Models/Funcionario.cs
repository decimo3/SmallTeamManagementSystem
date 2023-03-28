// Data Annotations - Conceitos Básicos
// System.ComponentModel.DataAnnotations
// https://macoratti.net/13/12/c_vdda.htm
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mestreruan.api.Models;
[Table("funcionario")]
public class Funcionario
{
  [Required]
  [MaxLength(11)]
  public string? cpf {get; set;}
  [Key]
  public int re {get; set;}
  [Required]
  public int matricula {get; set;}
  [Required]
  [MaxLength(16)]
  public string? nome {get; set;}
  [Required]
  [MaxLength(120)]
  public string? sobrenome {get; set;}
  [MaxLength(16)]
  public string? apelido {get; set;} // opcional
  [MaxLength(32)]
  public string? senha {get; set;}   // opcional
  [Required]
  public Funcao funcao {get; set;} = Funcao.Eletricista;
  [Required]
  public Situacao situacao {get; set;} = Situacao.Ativo;
  [Required]
  public Escala escala {get; set;} = Escala.segSex;
  public enum Funcao {Eletricista, Supervisor, Administrativo}
  public enum Situacao {Ativo, INSS, Demitido, Ferias}
  public enum Escala {segSex, terSab}
}
