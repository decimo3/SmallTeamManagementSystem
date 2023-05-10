namespace mestreruan.api.controllers;
using Microsoft.AspNetCore.Mvc;
using mestreruan.api.Entities;
using mestreruan.api.Database;
[ApiController]
[Route("api/[controller]")]
public class TelefoneController : ControllerBase
{
  [HttpGet(Name = "recuperarTelefones")]
  public ActionResult<IEnumerable<Telefone>> Get()
  {
    try
    {
      using(var dbContext = new DataBaseContext())
      {
        return (from t in dbContext.Telefones where t.situacaoTelefone == Telefone.SituacaoTelefone.Ativo select t).ToList();
      }
    }
    catch
    {
      return BadRequest();
    }
  }
  [HttpPost(Name = "inserirTelefone")]
  public ActionResult Post(Telefone telefone)
  {
    try
    {
      using(var dbContext = new DataBaseContext())
      {
        dbContext.Telefones.Add(telefone);
        dbContext.SaveChanges();
        return Created(telefone.numero.ToString(), telefone);
      }
    }
    catch
    {
      return BadRequest();
    }
  }
  [HttpPut(Name = "atualizarTelefone")]
  public ActionResult Put(Telefone telefone)
  {
    try
    {
      using(var dbContext = new DataBaseContext())
      {
        dbContext.Telefones.Update(telefone);
        dbContext.SaveChanges();
        return NoContent();
      }
    }
    catch
    {
      return BadRequest();
    }
  }
  [HttpDelete(Name = "removerTelefone")]
  public ActionResult Delete(Telefone telefone)
  {
    try
    {
      using(var dbContext = new DataBaseContext())
      {
        dbContext.Telefones.Remove(telefone);
        dbContext.SaveChanges();
        return NoContent();
      }
    }
    catch
    {
      return BadRequest();
    }
  }
}
