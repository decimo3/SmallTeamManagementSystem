namespace mestreruan.api.controllers;
using mestreruan.api.Entities;
using mestreruan.api.Database;

[Microsoft.AspNetCore.Mvc.ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]

public class FuncionarioController : Microsoft.AspNetCore.Mvc.ControllerBase
{
  [Microsoft.AspNetCore.Mvc.HttpGet(Name = "recuperarEletricistasAtivos")]
  public Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<Funcionario>> Get()
  {
    try
    {
      using(var dbContext = new DataBaseContext())
      {
        return (from f in dbContext.Funcionarios
                where (f.funcao == Funcionario.Funcao.Eletricista && f.situacaoFuncionario == Funcionario.SituacaoFuncionario.Ativo)
                select f).ToList();
      }
    }
    catch (System.InvalidOperationException)
    {
      return NotFound();
    }
  }
  [Microsoft.AspNetCore.Mvc.HttpGet("{re}", Name = "recuperarFuncionario")]
  public Microsoft.AspNetCore.Mvc.ActionResult<Funcionario> Get(int re)
  {
    try
    {
      using(var dbContext = new DataBaseContext())
      {
        return (from f in dbContext.Funcionarios
                where f.re == re
                select f).Single();
      }
    }
    catch (System.InvalidOperationException)
    {
      return NotFound();
    }
  }
  [Microsoft.AspNetCore.Mvc.HttpPost(Name = "inserirFuncionario")]
  public Microsoft.AspNetCore.Mvc.ActionResult Post(Funcionario funcionario)
  {
    try
    {
      using(var dbContext = new DataBaseContext())
      {
        dbContext.Funcionarios.Add(funcionario);
        dbContext.SaveChanges();
      }
      return NoContent();
    }
    catch (System.InvalidOperationException)
    {
      return BadRequest();
    }
  }
  [Microsoft.AspNetCore.Mvc.HttpPut(Name = "AlterarFuncionario")]
  public Microsoft.AspNetCore.Mvc.ActionResult Put(Funcionario funcionario)
  {
    try
    {
      using(var dbContext = new DataBaseContext())
      {
        dbContext.Funcionarios.Update(funcionario);
        dbContext.SaveChanges();
      }
      return NoContent();
    }
    catch (System.InvalidOperationException)
    {
      return BadRequest();
    }
  }
  [Microsoft.AspNetCore.Mvc.HttpDelete(Name = "ApagarFuncionario")]
  public Microsoft.AspNetCore.Mvc.ActionResult Delete(Funcionario funcionario)
  {
    try
    {
      using(var dbContext = new DataBaseContext())
      {
        dbContext.Funcionarios.Remove(funcionario);
        dbContext.SaveChanges();
      }
      return NoContent();
    }
    catch (System.InvalidOperationException)
    {
      return BadRequest();
    }
  }
}
