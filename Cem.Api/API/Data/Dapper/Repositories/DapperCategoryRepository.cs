using Cem.Api.Models;

namespace CemApi.Data.Dapper;

public class DapperCategoryRepository : DapperRepository<Category>
{
    protected override CrudStoredProceduresNames SpNames  => new() 
    {
        SelectSpName = "Category_Select",
        InsertSpName = "Category_Insert",
    };

    public DapperCategoryRepository(DapperDbManager dapperDbManager) : base(dapperDbManager)
    {     
    }
}