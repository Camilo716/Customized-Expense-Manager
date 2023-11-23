using Microsoft.Data.SqlClient;

namespace Common.DatabaseHelpers;

public class AdoDatabaseReinitalizer : IDatabaseReinitializer
{
    private readonly string _connection;

    public AdoDatabaseReinitalizer(string connection)
    {
        _connection = connection;    
    }
    public void ReinitializeDatabase()
    {
        using var sqlConnection = new SqlConnection(_connection);
        sqlConnection.Open();

        CleanDatabase(sqlConnection); 
    }

    private static void CleanDatabase(SqlConnection sqlConnection)
    {
        using var command = new SqlCommand
        (
            "DELETE FROM [Transaction];" +
            "DELETE FROM [Category];", 

            sqlConnection
        );

        command.ExecuteNonQuery();
    }
}