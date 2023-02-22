namespace mestreruan.api.Model;
public static class Database
{
  private static string connectionString = $"Host=localhost;Username=usuario;Password=123456789;Database=aplicacao";
  public static void execute(string commandText)
  {
    using(var connection = new Npgsql.NpgsqlConnection())
    {
      connection.ConnectionString = connectionString;
      connection.Open();
      using (var command = new Npgsql.NpgsqlCommand())
      {
        command.Connection = connection;
        command.CommandText = @commandText;
        command.ExecuteNonQuery();
      }
      if (connection.State == System.Data.ConnectionState.Open) connection.Close();
    }
  }
  public static Dictionary<string,object> recover(string commandText)
  {
    var linha = new System.Collections.Generic.Dictionary<string, object>();
    using(var connection = new Npgsql.NpgsqlConnection())
    {
      connection.ConnectionString = connectionString;
      connection.Open();
      using (var command = new Npgsql.NpgsqlCommand())
      {
        command.Connection = connection;
        command.CommandText = @commandText;
        using(var result = command.ExecuteReader(System.Data.CommandBehavior.Default))
        {
          if(!result.HasRows) throw new System.Exception("As informações solicitadas não foram encontradas no banco de dados!");
          for (int i = 0; i < result.FieldCount; i++)
          {
            linha.Add(result.GetName(i), result.GetValue(i));
          }
          return linha;
        }
      }
    }
  }
}