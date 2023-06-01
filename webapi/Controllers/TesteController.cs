namespace mestreruan.api.controllers;
using Microsoft.AspNetCore.Mvc;
using mestreruan.api.Services;
[ApiController]
[Route("api/[controller]")]
public class TesteController : ControllerBase
{
  private DataBaseContext dbContext;
  public TesteController(DataBaseContext dbContext)
  {
    this.dbContext = dbContext;
  }
  [HttpGet]
  public string Get()
  {
    var a = this.dbContext.Funcionarios.Find("12345678");
    return a.apelido;
  }
}