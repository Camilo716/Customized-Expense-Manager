using System.Data;
using CemApi.DTOs.Reports.MonthlyBalance;
using Dapper;

namespace CemApi.Data.Dapper;

public class DapperBalanceRepository : IBalanceRepository
{
    private readonly IDbConnection _connection;

    public DapperBalanceRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<MonthlyBalanceReport> GetMonthlyBalanceReport()
    {
        var parameters = new DynamicParameters();
        parameters.Add("TotalEarned", dbType: DbType.Decimal, direction: ParameterDirection.Output);
        parameters.Add("TotalSpent", dbType: DbType.Decimal, direction: ParameterDirection.Output);

        using SqlMapper.GridReader results = await _connection.QueryMultipleAsync(
            "MonthlyBalanceReport",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        List<BalancePerCategory> monthlyBalancesPerCategory = results.Read<BalancePerCategory>().ToList();

        var totalEarned = parameters.Get<decimal>("TotalEarned");
        var totalSpent = parameters.Get<decimal>("TotalSpent");

        return new MonthlyBalanceReport
        {
            MonthlyBalancesPerCategory = monthlyBalancesPerCategory,
            TotalEarned = Convert.ToDouble(totalEarned),
            TotalSpent = Convert.ToDouble(totalSpent)
        };
    }
}