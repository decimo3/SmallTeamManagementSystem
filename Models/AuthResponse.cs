namespace sge.Models;
using sge.Entities;
public class AuthResponse
{
    public int re {get; set;}
    public int matricula {get; set;}
    public string nome {get; set;}
    public string sobrenome {get; set;}
    public Funcionario.Funcao funcao {get; set;}
    public string token {get; set;}
    public AuthResponse(Funcionario user, string token)
    {
        this.re = user.re;
        this.matricula = user.matricula;
        this.nome = user.nome;
        this.sobrenome = user.sobrenome;
        this.funcao = user.funcao;
        this.token = token;
    }
}