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

    public async Task<MonthlyBalanceReport> GenerateMonthlyBalanceReport(BalanceReportCreationDTO balanceReportCreationDTO)
    {
        DynamicParameters parameters = GenerateParameters(balanceReportCreationDTO.Date);

        using SqlMapper.GridReader results = await _connection.QueryMultipleAsync(
            "MonthlyBalanceReport",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return BuildBalanceModelFromResults(results, parameters, balanceReportCreationDTO.Date);
    }

    private DynamicParameters GenerateParameters(DateTime date)
    {
        var parameters = new DynamicParameters();
        parameters.Add("TotalEarned", dbType: DbType.Decimal, direction: ParameterDirection.Output);
        parameters.Add("TotalSpent", dbType: DbType.Decimal, direction: ParameterDirection.Output);
        parameters.Add("Date", date.ToString("yyyy-MM-dd"), dbType: DbType.Date, direction: ParameterDirection.Input);
        return parameters;
    }

    private MonthlyBalanceReport BuildBalanceModelFromResults(SqlMapper.GridReader results, DynamicParameters parameters, DateTime date)
    {
        List<BalancePerCategory> monthlyBalancesPerCategory = results.Read<BalancePerCategory>().ToList();

        var totalEarned = parameters.Get<decimal>("TotalEarned");
        var totalSpent = parameters.Get<decimal>("TotalSpent");
        
        return new MonthlyBalanceReport
        {
            MonthlyBalancesPerCategory = monthlyBalancesPerCategory,
            TotalEarned = Convert.ToDouble(totalEarned),
            TotalSpent = Convert.ToDouble(totalSpent),
            Date = date
        };
    }
}