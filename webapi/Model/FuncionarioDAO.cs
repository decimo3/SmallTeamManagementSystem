using mestreruan.api.Models;
using mestreruan.api.Database;
namespace mestreruan.api.Model;
public static class FuncionarioDAO
{
  public static List<Funcionario> recuperarFuncionarios(Funcionario.Situacao situacao, Funcionario.Funcao funcao)
  {
    Funcionario.Escala? escala;
    switch(DateTime.Today.DayOfWeek)
    {
      case DayOfWeek.Monday:
        escala = Funcionario.Escala.segSex;
        break;
      case DayOfWeek.Tuesday:
      case DayOfWeek.Wednesday:
      case DayOfWeek.Thursday:
      case DayOfWeek.Friday:
        escala = null;
        break;
      case DayOfWeek.Saturday:
        escala = Funcionario.Escala.terSab;
        break;
      default:
        throw new InvalidOperationException("Não há ninguém disponível no domingo");
    }
    using(var dbContext = new DataBaseContext())
    {
      if(escala == null)
      {
        return (from f in dbContext.Funcionarios
                where (f.funcao == funcao && f.situacao == situacao && f.escala == escala)
                select new Funcionario()).ToList();
      }
      else
      {
        return (from f in dbContext.Funcionarios
                where (f.funcao == funcao && f.situacao == situacao)
                select new Funcionario()).ToList();
      }
    }
  }
  public static mestreruan.api.Models.Funcionario recuperarFuncionario(int re)
  {
    using(var dbContext = new DataBaseContext())
    {
      return (from f in dbContext.Funcionarios
              where f.re == re
              select new Funcionario()).Single();
    }
  }
  public static void inserirFuncionario(mestreruan.api.Models.Funcionario funcionario)
  {
    using(var dbContext = new DataBaseContext())
    {
      dbContext.Funcionarios.Add(funcionario);
      dbContext.SaveChanges();
    }
  }
  public static void alterarFuncionario(mestreruan.api.Models.Funcionario funcionario)
  {
    using(var dbContext = new DataBaseContext())
    {
      dbContext.Funcionarios.Update(funcionario);
      dbContext.SaveChanges();
    }
  }
  public static void apagarFuncionario(mestreruan.api.Models.Funcionario funcionario)
  {
    using(var dbContext = new DataBaseContext())
    {
      dbContext.Funcionarios.Remove(funcionario);
      dbContext.SaveChanges();
    }
  }
}
