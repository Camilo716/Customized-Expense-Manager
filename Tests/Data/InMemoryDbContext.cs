using Microsoft.EntityFrameworkCore;

using CEM.Context;


namespace CEM.Tests.Context;

public class InMemoryDbContext : DbCemContext
{
    public InMemoryDbContext(DbContextOptions<DbCemContext> options) : base(options){ }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("InMemoryDataBase");
    }
}