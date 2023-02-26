// using System.Data;
// using Microsoft.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

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
  public static void inserirFuncionario(mestreruan.api.Models.Funcionario funcionario)
  {
    using(var connection = new Npgsql.NpgsqlConnection(connectionString))
    {
      connection.Open();
      connection.Insert<mestreruan.api.Models.Funcionario>(funcionario);
      connection.Close();
    }
  }
  public static void alterarFuncionario(mestreruan.api.Models.Funcionario funcionario)
  {
    using(var connection = new Npgsql.NpgsqlConnection(connectionString))
    {
      connection.Open();
      connection.Update<mestreruan.api.Models.Funcionario>(funcionario);
      connection.Close();
    }
  }
  public static void apagarFuncionario(mestreruan.api.Models.Funcionario funcionario)
  {
    using(var connection = new Npgsql.NpgsqlConnection(connectionString))
    {
      connection.Open();
      connection.Delete<mestreruan.api.Models.Funcionario>(funcionario);
      connection.Close();
    }
  }
}