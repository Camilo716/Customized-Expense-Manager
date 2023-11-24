using CEM.Repositories;
using CemApi.DTOs;
using Cem.Api.Models;
using Cem.Api.DateManagement;

namespace CemApi.Services;

public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IDateManager _dateManager;

    public TransactionService(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository, IDateManager dateManager)
    {
        _transactionRepository = transactionRepository;
        _categoryRepository = categoryRepository;
        _dateManager = dateManager;
    }

    public void MakeTransaction(TransactionDTO transactionDto)
    {
        TryCreateCategory(categoryName: transactionDto.Category);

        Category categoryOftransaction =_categoryRepository.GetCategoryByName(transactionDto.Category);

        _transactionRepository.SaveTransaction
        (
            new Transaction 
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
            _categoryRepository.CreateNewCategory(categoryName);
    }

    private bool CategoryAlreadyExist(string categoryName)
    {
        List<Category> allCategories = _categoryRepository.GetAllCategories().ToList();

        foreach (Category categ in allCategories)
        {
            if (categ.Name == categoryName)
                return true;
        }
        return false;
    }
}