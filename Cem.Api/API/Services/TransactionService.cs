using CEM.Repositories;
using CemApi.DTOs;
using Cem.Api.Models;
using Cem.Api.DateManagement;
using CemApi.Data;

namespace CemApi.Services;

public class TransactionService
{
    private readonly IRepository<Transaction> _transactionRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IDateManager _dateManager;

    public TransactionService(IRepository<Transaction> transactionRepository, IRepository<Category> categoryRepository, IDateManager dateManager)
    {
        _transactionRepository = transactionRepository;
        _categoryRepository = categoryRepository;
        _dateManager = dateManager;
    }

    public void MakeTransaction(TransactionDTO transactionDto)
    {
        TryCreateCategory(categoryName: transactionDto.Category);

        Category categoryOftransaction =_categoryRepository.FindAsync(new 
            {
                Name = transactionDto.Category
            }
        ).Result.FirstOrDefault()!;

        _transactionRepository.InsertAsync
        (
            new 
            {
                Description = transactionDto.Description,
                Amount = float.Parse(transactionDto.Amount),
                TransactionType = transactionDto.RequestType,
                Date = _dateManager.GetCurrentDate(),
                CategoryId = categoryOftransaction.Id
            }
        );
    }

    private void TryCreateCategory(string categoryName)
    {
        if (!CategoryAlreadyExist(categoryName))
            _categoryRepository.InsertAsync(new { Name = categoryName }).Wait();
    }

    private bool CategoryAlreadyExist(string categoryName)
    {
        List<Category> allCategories = _categoryRepository.FindAsync(new { }).Result.ToList();

        foreach (Category categ in allCategories)
        {
            if (categ.Name == categoryName)
                return true;
        }
        return false;
    }
}