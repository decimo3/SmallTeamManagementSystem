using Microsoft.AspNetCore.Mvc;
using sge.Models;
using sge.Services;
namespace sge.Controllers;
public class AuthController : Controller
{
  private readonly DataBaseContext _context;
  private readonly IAuthService _service;
  public AuthController(DataBaseContext context, IAuthService service)
  {
    _context = context;
    _service = service;
  }
  [HttpGet]
  public IActionResult Login()
  {
    return View();
  }
  [HttpGet]
  public IActionResult Recovery()
  {
    return View();
  }
  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Login(AuthRequest authRequest)
  {
    if(!ModelState.IsValid) return View("Login");
    var token = _service.Authenticate(authRequest);
    if(token is null) return View("Login");
    return View("Login");// Ok(token)
  }
}