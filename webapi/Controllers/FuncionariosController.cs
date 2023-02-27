namespace mestreruan.api.controllers;

[Microsoft.AspNetCore.Mvc.ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]

public class Funcionarios : Microsoft.AspNetCore.Mvc.ControllerBase
{
  [Microsoft.AspNetCore.Mvc.HttpGet("{situacao}/{funcao}/{escala}",Name = "recuperarEletricistasAtivos")]
  public IEnumerable<mestreruan.api.Models.Funcionario> Get(int situacao, int funcao, int escala)
  {
    return mestreruan.api.Model.FuncionarioDAO.recuperarFuncionarios(situacao: situacao, funcao: funcao, escala: escala);
  }
  [Microsoft.AspNetCore.Mvc.HttpGet("{situacao}/{funcao}", Name = "recuperarEletricistas")]
  public IEnumerable<mestreruan.api.Models.Funcionario> Get(int situacao, int funcao)
  {
    return mestreruan.api.Model.FuncionarioDAO.recuperarFuncionarios(situacao: situacao, funcao: funcao);
  }
}