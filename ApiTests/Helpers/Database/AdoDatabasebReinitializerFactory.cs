namespace ApiTests.Helpers.Database;

public class AdoDatabasebReinitializerFactory : IDatabaseReinitializaerFactory
{
    public IDatabaseReinitializer Create()
    {
        string connection = "Data Source=172.17.0.2; Initial Catalog=CemDatabase; User Id=sa; password=debCasango*;TrustServerCertificate=true";
        return new AdoDatabaseReinitalizer(connection);
    }
}
