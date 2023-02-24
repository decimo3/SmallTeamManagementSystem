namespace mestreruan.api.Models;
public class Viatura
{
  public string placa {get; set;}
  public int ordem {get; set;}
  public string marcaModelo {get; set;}
  public string? chassi {get; set;} // opcional
  public Situacao situacao {get; set;}
  public enum Situacao {Ativo, Manutencao, Devolvido, Reserva}
}