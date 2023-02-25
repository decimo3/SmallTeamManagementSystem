// using System.Data;
// using Microsoft.Data.SqlClient;
using Dapper;

namespace mestreruan.api.Model;
public static class FuncionarioDAO
{
  private static string connectionString = $"Host=localhost;Username=usuario;Password=123456789;Database=aplicacao";
  public static IEnumerable<mestreruan.api.Models.Funcionario> recuperarFuncionarios()
  {
    using(var connection = new Npgsql.NpgsqlConnection(connectionString))
    {
      connection.Open();
      return connection.Query<mestreruan.api.Models.Funcionario>(@$"SELECT * FROM funcionario");
      connection.Close();
    }
  }
  public static mestreruan.api.Models.Funcionario recuperarFuncionario(int re)
  {
    using(var connection = new Npgsql.NpgsqlConnection(connectionString))
    {
      connection.Open();
      return connection.QuerySingle<mestreruan.api.Models.Funcionario>(@$"SELECT * FROM funcionario WHERE re = '{@re}'");
      connection.Close();
    }
  }
  public static void inserirFuncionario(mestreruan.api.Models.Funcionario f)
  {
    using(var connection = new Npgsql.NpgsqlConnection(connectionString))
    {
      connection.Open();
      connection.Execute(@"INSERT INTO public.funcionario(cpf, re, matricula, nome, sobrenome, apelido, senha, funcao, situacao, escala) VALUES (@cpf, @re, @matricula, @nome, @sobrenome, @apelido, @senha, @funcao, @situacao, @escala)",
        new {cpf = f.cpf, re = f.re, matricula = f.matricula, nome = f.nome, sobrenome = f.sobrenome, apelido = f.apelido, senha = f.senha, funcao = f.funcao, situacao = f.situacao, escala = f.escala});
      connection.Close();
    }
  }
}