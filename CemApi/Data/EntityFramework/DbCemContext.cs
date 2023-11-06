using CemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CEM.Context; 

public class DbCemContext : DbContext
{
    public DbSet<Category> Categories{get;set;}
    public DbSet<Transaction> Transactions{get;set;}

    public DbCemContext (DbContextOptions<DbCemContext> options) : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Category>(category =>
        {
            category.HasKey(c => c.Id);
            category.Property(e => e.Name).IsRequired();

            category.HasMany(c => c.TransactionsInCategory)
                    .WithOne(t => t.CategoryOfTransaction)
                    .HasForeignKey(t => t.TransactionID)
                    .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Transaction>(transaction =>
        {
            transaction.HasKey(t => t.TransactionID);
            transaction.Property(t=> t.Description).IsRequired();
            transaction.Property(t => t.Amount).IsRequired();
            transaction.Property(t => t.TransactionType).IsRequired();

            transaction.HasOne(t => t.CategoryOfTransaction)
                        .WithMany(c => c.TransactionsInCategory)
                        .HasForeignKey(t => t.CategoryId);
        });
    }  
}