using Microsoft.AspNetCore.Mvc;
using sge.Models;
namespace sge.Controllers;
public class AuthController : Controller
{
  public IActionResult Login()
  {
    return View();
  }
  public IActionResult Recovery()
  {
    return View();
  }
}