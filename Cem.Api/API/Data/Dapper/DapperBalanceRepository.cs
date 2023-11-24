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

    public async Task<MonthlyBalanceReport> GenerateMonthlyBalanceReport(MonthlyBalanceReport monthlyBalanceReport)
    {
        DynamicParameters parameters = GenerateParameters(monthlyBalanceReport.Date);

        using SqlMapper.GridReader results = await _connection.QueryMultipleAsync(
            "MonthlyBalanceReport",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return BuildBalanceModelFromResults(results, parameters, monthlyBalanceReport);
    }

    private DynamicParameters GenerateParameters(DateOnly date)
    {
        var parameters = new DynamicParameters();
        parameters.Add("TotalEarned", dbType: DbType.Decimal, direction: ParameterDirection.Output);
        parameters.Add("TotalSpent", dbType: DbType.Decimal, direction: ParameterDirection.Output);
        parameters.Add("Date", date, dbType: DbType.Date, direction: ParameterDirection.Input);
        return parameters;
    }

    private MonthlyBalanceReport BuildBalanceModelFromResults(SqlMapper.GridReader results, DynamicParameters parameters, MonthlyBalanceReport monthlyBalanceReport)
    {
        List<BalancePerCategory> monthlyBalancesPerCategory = results.Read<BalancePerCategory>().ToList();

        var totalEarned = parameters.Get<decimal>("TotalEarned");
        var totalSpent = parameters.Get<decimal>("TotalSpent");

        monthlyBalanceReport.MonthlyBalancesPerCategory = monthlyBalancesPerCategory; 
        monthlyBalanceReport.TotalEarned = Convert.ToDouble(totalEarned);
        monthlyBalanceReport.TotalSpent = Convert.ToDouble(totalSpent);
        return monthlyBalanceReport;
    }
}