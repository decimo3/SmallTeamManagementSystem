namespace mestreruan.api.controllers;
using mestreruan.api.Models;
using mestreruan.api.Database;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class EquipeController : ControllerBase
{
  [HttpGet("{ano}/{mes}/{dia}", Name = "recuperarEquipes")]
  public ActionResult<IEnumerable<Equipe>> Get(int ano, int mes, int dia)
  {
    var data = new DateTime(year:ano, month:mes, day:dia);
    try
    {
      using(var dbContex = new DataBaseContext())
      {
        return (from e in dbContex.Equipes where e.dia == data select e).ToList();
      }
    }
    catch
    {
      return BadRequest();
    }
  }
  [HttpGet("{ano}/{mes}/{dia}/{servico}/{espelho}", Name = "recuperarEquipe")]
  public ActionResult<IEnumerable<Equipe>> Get(int ano, int mes, int dia, int servico, int espelho)
  {
    var data = new DateTime(year:ano, month:mes, day:dia);
    var tipoServico = (Equipe.Servico)servico;
    try
    {
      using(var dbContex = new DataBaseContext())
      {
        return (from e in dbContex.Equipes where (e.dia == data && e.servico == tipoServico && e.espelho == espelho) select e).ToList();
      }
    }
    catch
    {
      return BadRequest();
    }
  }
  [HttpPost(Name = "inserirEquipe")]
  public ActionResult Post(Equipe equipe)
  {
    try
    {
      using(var dbContex = new DataBaseContext())
      {
        dbContex.Equipes.Add(equipe);
        dbContex.SaveChanges();
        return NoContent();
      }
    }
    catch
    {
      return BadRequest();
    }
  }
}



