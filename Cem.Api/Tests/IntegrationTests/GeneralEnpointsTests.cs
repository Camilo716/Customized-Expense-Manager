using Common.DatabaseHelpers;
using IntegrationTests.Helpers;

namespace IntegrationTests;

public partial class EnpointsTests 
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public EnpointsTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        ReinitializeDb();
    }

    [Theory]
    [InlineData("/api/category")]
    public async Task GetAllRecordsTest(string url)
    {
        HttpClient client = _factory.CreateClient();

        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
    }

    private static void ReinitializeDb()
    {
        IDatabaseReinitializerFactory dbReinitializerFactory = new AdoDatabaseReinitializerFactory();
        IDatabaseReinitializer databaseReinitializer = dbReinitializerFactory.Create();
        databaseReinitializer.ReinitializeDatabase();
    }
}