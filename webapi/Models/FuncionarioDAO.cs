using mestreruan.api.Entities;
using mestreruan.api.Database;
namespace mestreruan.api.Models;
public static class FuncionarioDAO
{
  public static List<mestreruan.api.Entities.Funcionario> recuperarFuncionarios()
  {
    using(var dbContext = new DataBaseContext())
    {
      return (from f in dbContext.Funcionarios
              where (f.funcao == Funcionario.Funcao.Eletricista && f.situacaoFuncionario == Funcionario.SituacaoFuncionario.Ativo)
              select f).ToList();
    }
  }
  public static List<Funcionario> recuperarFuncionarios(Funcionario.SituacaoFuncionario situacao, Funcionario.Funcao funcao)
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
                where (f.funcao == funcao && f.situacaoFuncionario == situacao)
                select f).ToList();
      }
      else
      {
        return (from f in dbContext.Funcionarios
                where (f.funcao == funcao && f.situacaoFuncionario == situacao && f.escala == escala)
                select f).ToList();
      }
    }
  }
  public static Funcionario recuperarFuncionario(int re)
  {
    using(var dbContext = new DataBaseContext())
    {
      return (from f in dbContext.Funcionarios
              where f.re == re
              select f).Single();
    }
  }
  public static void inserirFuncionario(Funcionario funcionario)
  {
    using(var dbContext = new DataBaseContext())
    {
      dbContext.Funcionarios.Add(funcionario);
      dbContext.SaveChanges();
    }
  }
  public static void alterarFuncionario(Funcionario funcionario)
  {
    using(var dbContext = new DataBaseContext())
    {
      dbContext.Funcionarios.Update(funcionario);
      dbContext.SaveChanges();
    }
  }
  public static void apagarFuncionario(Funcionario funcionario)
  {
    using(var dbContext = new DataBaseContext())
    {
      dbContext.Funcionarios.Remove(funcionario);
      dbContext.SaveChanges();
    }
  }
}
