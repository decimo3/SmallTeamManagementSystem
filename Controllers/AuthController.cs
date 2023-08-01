using Microsoft.AspNetCore.Mvc;
using sge.Models;
using sge.Services;
namespace sge.Controllers;
public class AuthController : Controller
{
  private readonly IAuthService AuthService;
  private readonly IHttpContextAccessor context;
  public AuthController(IAuthService AuthService, IHttpContextAccessor context)
  {
    this.AuthService = AuthService;
    this.context = context;
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
    var auth = AuthService.Authenticate(authRequest);
    if(auth is null) return View("Login");
    var options = new CookieOptions();
    options.Expires = DateTime.Now.AddDays(7);
    options.Secure = true; // define a cookie como seguro, somente será enviado em conexões HTTPS.
    options.HttpOnly = true; // define a cookie como acessível somente por HTTP, não pode ser acessado por JavaScript.
    context.HttpContext.Response.Cookies.Append("MeuCookie", auth.token, options);
    return RedirectToAction(controllerName: "Home", actionName: "Index");
  }
}