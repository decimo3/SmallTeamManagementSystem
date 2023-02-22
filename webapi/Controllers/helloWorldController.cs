namespace mestreruan.api.controllers;

[Microsoft.AspNetCore.Mvc.ApiController]
[Microsoft.AspNetCore.Mvc.Route("[controller]")]

public class HelloWorld : Microsoft.AspNetCore.Mvc.ControllerBase
{
  [Microsoft.AspNetCore.Mvc.HttpGet(Name = "GetHelloWorld")]
  public string Get()
  {
    return "Hello World!";
  }
  [Microsoft.AspNetCore.Mvc.HttpPost(Name = "PostHelloWorld")]
  public string Post(string a)
  {
    return a;
  }
}