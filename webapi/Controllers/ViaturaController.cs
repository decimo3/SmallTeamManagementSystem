namespace mestreruan.api.controllers;
using Microsoft.AspNetCore.Mvc;
using mestreruan.api.Entities;
using mestreruan.api.Services;
[ApiController]
[Route("api/[controller]")]
public class ViaturaController : ControllerBase
{
  [HttpGet("{placa}", Name = "recuperarViaturaAtiva")]
  public ActionResult<Viatura> Get(string placa)
  {
    try
    {
      using(var dbContex = new DataBaseContext())
      {
        return (from f in dbContex.Viaturas where (f.situacaoViatura == Viatura.SituacaoViatura.Ativo && f.placa == placa) select f).Single();
      }
    }
    catch
    {
      return NotFound();
    }
  }
  [HttpGet(Name = "recuperarViaturasAtivas")]
  public ActionResult<IEnumerable<Viatura>> Get()
  {
    try
    {
      using(var dbContex = new DataBaseContext())
      {
        return (from f in dbContex.Viaturas where f.situacaoViatura == Viatura.SituacaoViatura.Ativo select f).ToList();
      }
    }
    catch
    {
      return NotFound();
    }
  }
  [HttpPost(Name = "inserirViatura")]
  public ActionResult Post(Viatura viatura)
  {
    try
    {
      using(var dbContex = new DataBaseContext())
      {
        dbContex.Viaturas.Add(viatura);
        dbContex.SaveChanges();
        return NoContent();
      }
    }
    catch
    {
      return BadRequest();
    }
  }
  [HttpPut(Name = "atualizarViatura")]
  public ActionResult Put(Viatura viatura)
  {
    try
    {
      using(var dbContex = new DataBaseContext())
      {
        dbContex.Viaturas.Update(viatura);
        dbContex.SaveChanges();
        return NoContent();
      }
    }
    catch
    {
      return BadRequest();
    }
  }
  [HttpDelete(Name = "apagarViatura")]
  public ActionResult Delete(Viatura viatura)
  {
    try
    {
      using(var dbContex = new DataBaseContext())
      {
        dbContex.Viaturas.Remove(viatura);
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
