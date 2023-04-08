namespace CEM.Repositories;

public interface ITransactionRepository
{
    void makeTransaction(string description, int amount, string CategoryID);
}