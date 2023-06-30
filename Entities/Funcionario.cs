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
  [JsonIgnore]
  [Display(Name = "CPF")]
  public string? cpf {get; set;}
  [Key]
  [Display(Name = "Registro empregado (RE)")]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  [Required]
  public int re {get; set;}
  [Display(Name = "Matrícula cliente")]
  [Required]
  public int matricula {get; set;}
  [Required]
  [Display(Name = "Primeiro nome")]
  public string? nome {get; set;}
  [Required]
  [Display(Name = "Sobrenome completo")]
  public string? sobrenome {get; set;}
  [MaxLength(16)]
  [Display(Name = "Apelido")]
  public string? apelido {get; set;} // opcional
  [JsonIgnore]
  [Display(Name = "Senha")]
  public string? senha {get; set;}   // opcional
  [Required]
  [Display(Name = "Cargo")]
  public Funcao funcao {get; set;}
  [Required]
  [Display(Name = "Situação")]
  public SituacaoFuncionario situacaoFuncionario {get; set;}
  [Required]
  [Display(Name = "Escala de trabalho")]
  public Escala escala {get; set;}
  public enum Funcao {Eletricista, Supervisor, Administrativo}
  public enum SituacaoFuncionario {Ativo, INSS, Demitido, Ferias}
  public enum Escala {segSex, terSab}
  public IEnumerable<ValidationResult> Validate(ValidationContext context)
  {
    var validacoes = new List<ValidationResult>();
    var re = new System.Text.RegularExpressions.Regex("");
    // Validação da matricula do funcionario
    re = new System.Text.RegularExpressions.Regex("[0-9]{7}");
    if(!re.IsMatch(this.re.ToString()!)) validacoes.Add(new ValidationResult("O Registro Empregado informada não é válida!"));
    // Validação da matrícula do cliente
    re = new System.Text.RegularExpressions.Regex("[0-9]{6}");
    if(!re.IsMatch(this.matricula.ToString()!)) validacoes.Add(new ValidationResult("A matrícula Light informada não é válida!"));
    // Validação do CPF do funcionario
    re = new System.Text.RegularExpressions.Regex("[0-9]{11}");
    if(!re.IsMatch(this.cpf!)) validacoes.Add(new ValidationResult("O CPF informado não é válido!"));
    // Validação do nome do funcionario
    if(String.IsNullOrEmpty(this.nome))
    {
      validacoes.Add(new ValidationResult("O nome não pode estar vazio!"));
    }
    else
    {
      re = new System.Text.RegularExpressions.Regex("[A-z]{4,16}");
      if (!re.IsMatch(this.nome)) validacoes.Add(new ValidationResult("O nome tem que ter entre 4 e 16 e somente letras!"));
    }
    // Validação do sobrenome do funcionario
    if(String.IsNullOrEmpty(this.sobrenome))
    {
      validacoes.Add(new ValidationResult("O sobrenome não pode estar vazio!"));
    }
    else
    {
      re = new System.Text.RegularExpressions.Regex("[A-z ]{6,120}");
      if (!re.IsMatch(this.sobrenome)) validacoes.Add(new ValidationResult("O sobrenome deve ter entre 6 e 120 somente letras!"));
    }
    // Validação do campo de senha
    if(!String.IsNullOrEmpty(this.senha))
    {
      re = new System.Text.RegularExpressions.Regex("[A-z0-9]{32}");
      if (re.IsMatch(this.senha)) validacoes.Add(new ValidationResult("A senha está fora do padrão definido!"));
    }
    if(!String.IsNullOrEmpty(this.apelido))
    {
      re = new System.Text.RegularExpressions.Regex("[A-z ]{3,16}");
      if (re.IsMatch(this.apelido)) validacoes.Add(new ValidationResult("O apelido está fora do padrão definido!"));
    }
    return validacoes;
  }
}
