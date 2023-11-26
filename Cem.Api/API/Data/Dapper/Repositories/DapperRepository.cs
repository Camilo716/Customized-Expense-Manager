
using Dapper;

namespace CemApi.Data.Dapper;

public abstract class DapperRepository<T> : IRepository<T>
{
    private readonly DapperDbManager _dapperDbManager;
    protected abstract CrudStoredProceduresNames SpNames { get; }

    public DapperRepository(DapperDbManager dapperDbManager)
    {
        _dapperDbManager = dapperDbManager;
    }

    public async Task<IEnumerable<T>> FindAsync(object searchModel)
    {
        DynamicParameters parameters = GetParametersFromEntity(searchModel);
        return await _dapperDbManager.ExecuteStoredProcedureReaderAsync<T>(SpNames.SelectSpName, parameters);
    }

    public async Task<bool> InsertAsync(object model)
    {
        DynamicParameters parameters = GetParametersFromEntity(model);
        int affectedRows = await _dapperDbManager.ExecuteStoredProcedure(SpNames.InsertSpName, parameters);
        return affectedRows > 0;
    }

    private DynamicParameters GetParametersFromEntity(object entityParams)
    {
        var parameters = new DynamicParameters();

        foreach (var property in entityParams.GetType().GetProperties())
        {
            var value = property.GetValue(entityParams);
            parameters.Add(property.Name, value);
        }

        return parameters;
    }
}