using CEM.Repositories;
using CemApi.DTOs;
using CemApi.Models;

namespace CemApi.Services;

public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICategoryRepository _categoryRepository;

    public TransactionService(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository)
    {
        _transactionRepository = transactionRepository;
        _categoryRepository = categoryRepository;
    }

    public void MakeTransaction(ITransactionData transactionData)
    {
        ITransactionData _data = transactionData;

        TryCreateCategory(_data.GetCategory());
        
        _transactionRepository.AddTransaction
        (
            _data.GetDescription(),
            float.Parse(_data.GetAmount()),
            _data.GetRequestType(),
            _categoryRepository.GetCategoryByName(_data.GetCategory())
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
        
        for (int category = 0; category < allCategories.Count ; category++)
        {
            if (allCategories[category].Name == categoryName)
            {
                return true;
            }
        }

        return false;
    }
}