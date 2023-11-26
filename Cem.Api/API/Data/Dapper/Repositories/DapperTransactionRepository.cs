
using Cem.Api.Models;

namespace CemApi.Data.Dapper;

public class DapperTransactionRepository : DapperRepository<Transaction>
{
    protected override CrudStoredProceduresNames SpNames => new ()
    {
        InsertSpName = "Transaction_Insert"
    };

    public DapperTransactionRepository(DapperDbManager dapperDbManager) : base(dapperDbManager)
    {
    }

}