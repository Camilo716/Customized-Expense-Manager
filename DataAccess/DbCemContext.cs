using Microsoft.EntityFrameworkCore;
using CEM.Models;
using System.Collections.Generic;

namespace CEM.Context; 

public class DbCemContext : DbContext
{
    public DbSet<CategoryModel> Categories{get;set;}
    public DbSet<TransactionModel> Transactions{get;set;}

    public DbCemContext (DbContextOptions<DbCemContext> options) : base(options){ }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     private List<CategoryModel> categorySeed = new List<CategoryModel>{
    //         new CategoryModel{name = "Entertaiment"},
    //         new CategoryModel{name = "Education"},
    //         new CategoryModel{name = "Transport"}
    //     };



    //     // modelBuilder.Entity<CategoryModel>(category =>
    //     // {
    //     //     base.OnModelCreating(modelBuilder);

    //     //     category.HasKey(c => c.name);

    //     //     // modelBuilder.Entity<CategoryModel>()
    //     //     // .HasKey(c => c.name);

    //     //     // modelBuilder.Entity<CategoryModel>()
    //     //     // .HasMany(c => c.transactionsInCategory)
    //     //     // .WithOne(t => t.categoryOfTransaction)
    //     //     // .HasForeignKey(t => t.CategoryID)
    //     //     // .IsRequired();
    //     // });

    //     // modelBuilder.Entity<TransactionModel>(transaction =>
    //     // {
    //     //     base.OnModelCreating(modelBuilder);

    //     //     transaction.HasKey(t => t.transactionID);

    //     //     transaction.HasOne(t => t.CategoryOfTransaction).WithMany(c => c.transactionsInCategory);

    //     // });
    // }  
}