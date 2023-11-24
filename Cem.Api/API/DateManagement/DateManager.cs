

namespace Cem.Api.DateManagement;

public class DateManager : IDateManager
{
    public DateTime GetCurrentDate()
    {
        return DateTime.Now;
    }
}