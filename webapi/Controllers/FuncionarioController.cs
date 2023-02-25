namespace mestreruan.api.controllers;

[Microsoft.AspNetCore.Mvc.ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]

public class Funcionario : Microsoft.AspNetCore.Mvc.ControllerBase
{
  [Microsoft.AspNetCore.Mvc.HttpGet(Name = "GetFuncionarios")]
  public IEnumerable<mestreruan.api.Models.Funcionario> Get()
  {
    return mestreruan.api.Model.FuncionarioDAO.recuperarFuncionarios();
  }
  [Microsoft.AspNetCore.Mvc.HttpGet("{re}", Name = "GetFuncionario")]
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
  [Microsoft.AspNetCore.Mvc.HttpPost(Name = "PostFuncionario")]
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
}