using Cem.Api.Models;

namespace CemApi.Data.Dapper;

public class CategoryRepository : DapperRepository<Category>
{
    protected override CrudStoredProceduresNames SpNames 
    {  
        get => new() 
        {
            SelectSpName = "Category_Select",
            InsertSpName = "InsertCategory",
        };
    }

    public CategoryRepository(DapperDbManager dapperDbManager) : base(dapperDbManager)
    {     
    }
}