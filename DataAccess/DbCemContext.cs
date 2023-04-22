using Microsoft.EntityFrameworkCore;
using CEM.Models;

namespace CEM.Context; 

public class DbCemContext : DbContext
{
    public DbSet<CategoryModel> Categories{get;set;}
    public DbSet<TransactionModel> Transactions{get;set;}

    public DbCemContext (DbContextOptions<DbCemContext> options) : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryModel>(category =>
        {
            
        });
    }

    

    
}