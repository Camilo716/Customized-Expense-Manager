namespace CemApi.Data;

public interface IRepository<T>
{
    Task<IEnumerable<T>> FindAsync(T searchModel);
    Task<bool> InsertAsync(T model);
}
