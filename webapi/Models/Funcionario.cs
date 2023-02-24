// Data Annotations - Conceitos Básicos
// System.ComponentModel.DataAnnotations
// https://macoratti.net/13/12/c_vdda.htm
namespace mestreruan.api.Models;
public class Funcionario
{
  public string cpf {get; set;}
  public int re {get; set;}
  public int matricula {get; set;}
  public string nome {get; set;}
  public string sobrenome {get; set;}
  public string? apelido {get; set;} // opcional
  public string? senha {get; set;}   // opcional
  public Funcao funcao {get; set;} = Funcao.Eletricista;
  public Situacao situacao {get; set;} = Situacao.Ativo;
  public Escala escala {get; set;} = Escala.segSex;
  public enum Funcao {Eletricista, Supervisor, Administrativo}
  public enum Situacao {Ativo, INSS, Demitido, Ferias}
  public enum Escala {segSex, terSab}
}
