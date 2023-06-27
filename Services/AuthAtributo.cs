namespace sge.Services;
using Microsoft.AspNetCore.Mvc.Filters;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (sge.Entities.Funcionario?)context.HttpContext.Items["User"];
        // Se a variável 'user' for nulo, quer dizer que o usuário não está logado!
        if (user == null) context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
    }
}