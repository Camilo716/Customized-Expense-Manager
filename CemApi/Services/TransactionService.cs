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

    public void MakeTransaction(TransactionDTO transactionDto)
    {
        TryCreateCategory(categoryName: transactionDto.Category);

        _transactionRepository.AddTransaction
        (
            transactionDto.Description,
            float.Parse(transactionDto.Amount),
            transactionDto.RequestType,
            _categoryRepository.GetCategoryByName(transactionDto.Category)
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