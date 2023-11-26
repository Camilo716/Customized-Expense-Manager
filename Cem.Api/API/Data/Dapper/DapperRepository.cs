
using Dapper;

namespace CemApi.Data.Dapper;

public class DapperRepository<T> : IRepository<T>
{
    private readonly DapperDbManager _dapperDbManager;
    private readonly CrudStoredProceduresNames _spNames;

    public DapperRepository(DapperDbManager dapperDbManager, CrudStoredProceduresNames spNames)
    {
        _dapperDbManager = dapperDbManager;
        _spNames = spNames;
    }

    public async Task<IEnumerable<T>> FindAsync(T searchModel)
    {
        DynamicParameters parameters = GetParametersFromEntity(searchModel);
        return await _dapperDbManager.ExecuteStoredProcedureReaderAsync<T>(_spNames.SelectSpName, parameters);
    }

    public async Task<bool> InsertAsync(T model)
    {
        DynamicParameters parameters = GetParametersFromEntity(model);
        int affectedRows = await _dapperDbManager.ExecuteStoredProcedure(_spNames.InsertSpName, parameters);
        return affectedRows > 0;
    }

    private DynamicParameters GetParametersFromEntity(T entity)
    {
        var parameters = new DynamicParameters();

        foreach (var property in typeof(T).GetProperties())
        {
            var value = property.GetValue(entity);
            parameters.Add(property.Name, value);
        }

        return parameters;
    }
}