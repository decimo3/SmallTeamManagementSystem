namespace mestreruan.api.controllers;

[Microsoft.AspNetCore.Mvc.ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]

public class Eletricistas : Microsoft.AspNetCore.Mvc.ControllerBase
{
  [Microsoft.AspNetCore.Mvc.HttpGet(Name = "recuperarEletricistasAtivos")]
  public IEnumerable<mestreruan.api.Models.Funcionario> Get()
  {
    return mestreruan.api.Model.FuncionarioDAO.recuperarEletricistasAtivos();
  }
  [Microsoft.AspNetCore.Mvc.HttpGet("{funcao}", Name = "recuperarEletricistas")]
  public IEnumerable<mestreruan.api.Models.Funcionario> Get(string funcao)
  {
    return mestreruan.api.Model.FuncionarioDAO.recuperarFuncionarios(funcao);
  }
}