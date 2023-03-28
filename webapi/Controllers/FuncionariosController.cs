namespace mestreruan.api.controllers;
[Microsoft.AspNetCore.Mvc.ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
public class Funcionarios : Microsoft.AspNetCore.Mvc.ControllerBase
{
  [Microsoft.AspNetCore.Mvc.HttpGet("{situacao}/{funcao}",Name = "recuperarEletricistasAtivos")]
  public IEnumerable<mestreruan.api.Models.Funcionario> Get(mestreruan.api.Models.Funcionario.Situacao situacao, mestreruan.api.Models.Funcionario.Funcao funcao)
  {
    return mestreruan.api.Model.FuncionarioDAO.recuperarFuncionarios(situacao: situacao, funcao: funcao);
  }
}
