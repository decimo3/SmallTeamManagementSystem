namespace mestreruan.api.controllers;

[Microsoft.AspNetCore.Mvc.ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]

public class Funcionario : Microsoft.AspNetCore.Mvc.ControllerBase
{
  [Microsoft.AspNetCore.Mvc.HttpGet(Name = "recuperarEletricistasAtivos")]
  public Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<mestreruan.api.Models.Funcionario>> Get()
  {
    try
    {
      return mestreruan.api.Model.FuncionarioDAO.recuperarFuncionarios();
    }
    catch (System.InvalidOperationException)
    {
      return NotFound();
    }
  }
  [Microsoft.AspNetCore.Mvc.HttpGet("{re}", Name = "recuperarFuncionario")]
  public Microsoft.AspNetCore.Mvc.ActionResult<mestreruan.api.Models.Funcionario> Get(int re)
  {
    try
    {
      return mestreruan.api.Model.FuncionarioDAO.recuperarFuncionario(re);
    }
    catch (System.InvalidOperationException)
    {
      return NotFound();
    }
  }
  [Microsoft.AspNetCore.Mvc.HttpPost(Name = "inserirFuncionario")]
  public Microsoft.AspNetCore.Mvc.ActionResult Post(mestreruan.api.Models.Funcionario funcionario)
  {
    try
    {
      mestreruan.api.Model.FuncionarioDAO.inserirFuncionario(funcionario);
      return NoContent();
    }
    catch (System.InvalidOperationException)
    {
      return BadRequest();
    }
  }
  [Microsoft.AspNetCore.Mvc.HttpPut(Name = "AlterarFuncionario")]
  public Microsoft.AspNetCore.Mvc.ActionResult Put(mestreruan.api.Models.Funcionario funcionario)
  {
    try
    {
      mestreruan.api.Model.FuncionarioDAO.alterarFuncionario(funcionario);
      return NoContent();
    }
    catch (System.InvalidOperationException)
    {
      return BadRequest();
    }
  }
  [Microsoft.AspNetCore.Mvc.HttpDelete(Name = "ApagarFuncionario")]
  public Microsoft.AspNetCore.Mvc.ActionResult Delete(mestreruan.api.Models.Funcionario funcionario)
  {
    try
    {
      mestreruan.api.Model.FuncionarioDAO.apagarFuncionario(funcionario);
      return NoContent();
    }
    catch (System.InvalidOperationException)
    {
      return BadRequest();
    }
  }
}