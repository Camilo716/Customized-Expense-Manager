namespace Common.DatabaseHelpers;

public interface IDatabaseReinitializer
{
    void ReinitializeDatabase();
}

public interface ISeedDataDatabaseReinitializer : IDatabaseReinitializer
{
    void InsertSeedData();
}