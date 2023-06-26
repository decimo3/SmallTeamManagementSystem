// Data Annotations - Conceitos Básicos
// System.ComponentModel.DataAnnotations
// https://macoratti.net/13/12/c_vdda.htm
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sge.Entities;
[Table("funcionario")]
public class Funcionario : IValidatableObject
{
  [Required]
  [MaxLength(11)]
  [JsonIgnore]
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
  [JsonIgnore]
  [MaxLength(32)]
  public string? senha {get; set;}   // opcional
  [Required]
  public Funcao funcao {get; set;} = Funcao.Eletricista;
  [Required]
  public SituacaoFuncionario situacaoFuncionario {get; set;} = SituacaoFuncionario.Ativo;
  [Required]
  public Escala escala {get; set;} = Escala.segSex;
  public enum Funcao {Eletricista, Supervisor, Administrativo}
  public enum SituacaoFuncionario {Ativo, INSS, Demitido, Ferias}
  public enum Escala {segSex, terSab}
  public IEnumerable<ValidationResult> Validate(ValidationContext context)
  {
    var validacoes = new List<ValidationResult>();
    var re = new System.Text.RegularExpressions.Regex("[0-9]{11}");
    if(!re.IsMatch(this.cpf!)) validacoes.Add(new ValidationResult("O CPF informado não é válido!"));
    re = new System.Text.RegularExpressions.Regex("[A-z]{3,16}");
    if (!re.IsMatch(nome)) validacoes.Add(new ValidationResult("O nome tem que ter entre 3 e 16 e somente letras"));
    re = new System.Text.RegularExpressions.Regex("[A-z ]{6,120}");
    if (!re.IsMatch(sobrenome)) validacoes.Add(new ValidationResult("O sobrenome deve ter entre 6 e 120 somente letras"));
    return validacoes;
  }
}
