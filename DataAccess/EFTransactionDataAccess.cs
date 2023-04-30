// public class TransactionRepository : ITransactionRepository
// {
//     private readonly MyDbContext _dbContext;

//     public TransactionRepository(MyDbContext dbContext)
//     {
//         _dbContext = dbContext;
//     }

//     public void AddTransaction(string Description, float Amount, RequestType TransactionType, CategoryModel category)
//     {
//         TransactionModel transaction = new TransactionModel
//         {
//             Description = Description,
//             Amount = Amount,
//             TransactionType = TransactionType,
//             CategoryOfTransaction = category
//         };

//         _dbContext.Transactions.Add(transaction);
//         _dbContext.SaveChanges();
//     }

//     public List<TransactionModel> GetAllTransactionsByTypeAndCategory(RequestType TransactionType, CategoryModel category)
//     {
//         List<TransactionModel> transactions = _dbContext.Transactions.Where(t => t.TransactionType == TransactionType && t.CategoryOfTransaction == category).ToList();

//         return transactions;
//     }
// }