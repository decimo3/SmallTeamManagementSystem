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
    var data = new DateOnly(year:ano, month:mes, day:dia);
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
  [HttpPost(Name = "inserirEquipe")]
  public ActionResult Post(Equipe equipe)
  {
    try
    {
      using(var dbContex = new DataBaseContext())
      {
        equipe.ajudante = dbContex.Funcionarios.Find(equipe.ajudanteId);
        equipe.motorista = dbContex.Funcionarios.Find(equipe.motoristaId);
        equipe.supervisor = dbContex.Funcionarios.Find(equipe.supervisorId);
        equipe.telefone = dbContex.Telefones.Find(equipe.telefoneId);
        equipe.viatura = dbContex.Viaturas.Find(equipe.viaturaId);
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
  [HttpPut(Name = "alterarEquipe")]
  public ActionResult Put(Equipe equipe)
  {
    try
    {
      using(var dbContex = new DataBaseContext())
      {
        if(!(dbContex.Equipes.Find(equipe.servico, equipe.dia, equipe.espelho) is null))
        {
          equipe.ajudante = dbContex.Funcionarios.Find(equipe.ajudanteId);
          equipe.motorista = dbContex.Funcionarios.Find(equipe.motoristaId);
          equipe.supervisor = dbContex.Funcionarios.Find(equipe.supervisorId);
          equipe.telefone = dbContex.Telefones.Find(equipe.telefoneId);
          equipe.viatura = dbContex.Viaturas.Find(equipe.viaturaId);
          dbContex.Equipes.Update(equipe);
          dbContex.SaveChanges();
          return NoContent();
        }
        return NotFound();
      }
    }
    catch
    {
      return BadRequest();
    }
  }
  [HttpDelete(Name = "apagarEquipe")]
  public ActionResult Delete(Equipe equipe)
  {
    try
    {
      using(var dbContex = new DataBaseContext())
      {
        if(!(dbContex.Equipes.Find(equipe.servico, equipe.dia, equipe.espelho) is null))
        {
          equipe.ajudante = dbContex.Funcionarios.Find(equipe.ajudanteId);
          equipe.motorista = dbContex.Funcionarios.Find(equipe.motoristaId);
          equipe.supervisor = dbContex.Funcionarios.Find(equipe.supervisorId);
          equipe.telefone = dbContex.Telefones.Find(equipe.telefoneId);
          equipe.viatura = dbContex.Viaturas.Find(equipe.viaturaId);
          dbContex.Equipes.Remove(equipe);
          dbContex.SaveChanges();
          return NoContent();
        }
        return NotFound();
      }
    }
    catch
    {
      return BadRequest();
    }
  }
}



