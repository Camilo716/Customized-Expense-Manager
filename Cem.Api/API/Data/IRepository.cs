namespace CemApi.Data;

public interface IRepository<T>
{
    Task<IEnumerable<T>> FindAsync(object searchModel);
    Task<bool> InsertAsync(object model);
}
