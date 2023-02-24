namespace mestreruan.api.Models;
public class Equipe
{
  public int espelho {get; set;}
  public Servico servico {get; set;}
  public DateTime dia {get; set;}
  public int supervisor {get; set;}
  public int motorista {get; set;}
  public int ajudante {get; set;}
  public string viatura {get; set;}
  public enum Servico {Corte, Religa, PQMT, Negociacao, Inspecao, Cadastro}
}