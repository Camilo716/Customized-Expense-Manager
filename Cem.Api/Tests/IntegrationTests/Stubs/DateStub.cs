using Cem.Api.DateManagement;

namespace ApiTests.Stubs;

public class DateManagerStub : IDateManager
{
    public DateTime GetCurrentDate()
    {
        return new DateTime(2023, 12, 1);
    }
}