namespace Common.DatabaseHelpers;

public interface IDatabaseReinitializerFactory
{
    public IDatabaseReinitializer Create();
}