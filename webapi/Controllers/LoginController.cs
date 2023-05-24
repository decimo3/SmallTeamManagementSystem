namespace mestreruan.api.controllers;
using Microsoft.AspNetCore.Mvc;
using mestreruan.api.Models;
using mestreruan.api.Services;
[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
  private IAuthService authService;
  public LoginController(IAuthService authService)
  {
    this.authService = authService;
  }
  [HttpPost]
  public ActionResult<AuthResponse> Post(AuthRequest request)
  {
    var response = authService.Authenticate(request);
    if(response == null) return BadRequest(new { message = "Username or password is incorrect" });
    return Ok(response);
  }
  [Authorize]
  [HttpGet]
  public IActionResult GetAll()
  {
    var users = authService.GetAll();
    return Ok(users);
  }
}
