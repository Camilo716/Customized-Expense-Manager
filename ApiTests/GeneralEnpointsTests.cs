using IntegrationTests.Helpers;

namespace IntegrationTests;

public partial class EnpointsTests 
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public EnpointsTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
}