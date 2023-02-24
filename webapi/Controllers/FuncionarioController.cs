namespace mestreruan.api.controllers;

[Microsoft.AspNetCore.Mvc.ApiController]
[Microsoft.AspNetCore.Mvc.Route("[controller]")]

public class Funcionario : Microsoft.AspNetCore.Mvc.ControllerBase
{
  [Microsoft.AspNetCore.Mvc.HttpGet(Name = "GetFuncionarios")]
  public IEnumerable<mestreruan.api.Models.Funcionario> Get()
  {
    return mestreruan.api.Model.FuncionarioDAO.recuperarFuncionarios();
  }
}