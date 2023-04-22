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
            category.HasKey(c => c.name);
            // base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<CategoryModel>()
            // .HasKey(c => c.name);

            // modelBuilder.Entity<CategoryModel>()
            // .HasMany(c => c.transactionsInCategory)
            // .WithOne(t => t.categoryOfTransaction)
            // .HasForeignKey(t => t.CategoryID)
            // .IsRequired();
        });

        modelBuilder.Entity<TransactionModel>(transction =>
        {
            transction.HasKey(t => t.transactionID);

            //transction.HasOne(c => c.CategoryOfTransaction).WithMany(t => t.)
        });
    }

    

    
}