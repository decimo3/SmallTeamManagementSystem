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
  public static void inserirFuncionario(mestreruan.api.Models.Funcionario funcionario)
  {
    
  }
}