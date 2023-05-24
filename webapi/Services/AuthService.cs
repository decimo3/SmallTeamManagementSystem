namespace mestreruan.api.Services;
using mestreruan.api.Entities;
using mestreruan.api.Database;
using mestreruan.api.Models;
public interface IAuthService
{
    AuthResponse Authenticate(AuthRequest model);
    IEnumerable<Funcionario>? GetAll();
    Funcionario? GetById(int re);
}
public class AuthService : IAuthService
{
    private readonly string segredo = System.Environment.GetEnvironmentVariable("SECRET");
    public IEnumerable<Funcionario>? GetAll()
    {
        using(var dbContext = new DataBaseContext())
        {
            try
            {
                return dbContext.Funcionarios.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
    public Funcionario? GetById(int re)
    {
        using(var dbContext = new DataBaseContext())
        {
            try
            {
                return dbContext.Funcionarios.Find(re);
            }
            catch
            {
                return null;
            }
        }
    }
    private string generateJwtToken(Funcionario funcionario)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        var key = System.Text.Encoding.ASCII.GetBytes(segredo);
        var symmetricKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key);
        var claimRe = new System.Security.Claims.Claim("re", funcionario.re.ToString());
        var claimFn = new System.Security.Claims.Claim("funcao", funcionario.funcao.ToString());
        var claims = new[] { claimRe, claimFn };
        var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(symmetricKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public AuthResponse Authenticate(AuthRequest model)
    {
        using(var dbContext = new DataBaseContext())
        {
            try
            {
                var user = (from u in dbContext.Funcionarios where (u.matricula == model.matricula && u.senha == model.palavra) select u).Single(); // u.senha != null &&
                var token = generateJwtToken(user);
                return new AuthResponse(user, token);
            }
            catch
            {
                return null;
            }
        }
    }
}