
using Cem.Api.Models;

namespace CemApi.Data.Dapper;

public class TransactionRepository : DapperRepository<Transaction>
{
    protected override CrudStoredProceduresNames SpNames => new ()
    {
        InsertSpName = "InsertTransaction"
    };

    public TransactionRepository(DapperDbManager dapperDbManager) : base(dapperDbManager)
    {
    }

}