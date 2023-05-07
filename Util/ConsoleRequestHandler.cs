namespace CEM.Util;

public class ConsoleRequestHandler
{
    private readonly string[] _receivedArgs;
    private ITransactionData _transactionData;

    public ConsoleRequestHandler(string[] args)
    {
        _receivedArgs = args;
        _transactionData = new TransactionData();
    }

    public ITransactionData GetTransactionData()
    {
        return _transactionData;
    }

    public void ProcessRequest()
    {
        if (ArgumentsOK() && RequestOK())
        {
            setValues();
        }

        // Console.WriteLine("Category: " + _transactionData.GetCategory());
        // Console.WriteLine("Description: " + _transactionData.GetDescription());
        // Console.WriteLine("Amount: " + _transactionData.GetAmount());
        // Console.WriteLine("Type: " + _transactionData.GetRequestType());
    }

    private bool ArgumentsOK()
    {
        bool invalidArguments = _receivedArgs.Length != 4;

        if (invalidArguments)
        {
            //Console.WriteLine($"Missing argument: --type <category> <Description> <value>");
            return false;
        }
        return true;
    }

    private bool RequestOK()
    {
        switch (_receivedArgs[0])
        {
            case "--expense":
                _transactionData.SetRequestType(RequestType.Expense);
                return true;
    
            case "--income":
                _transactionData.SetRequestType(RequestType.Income);
                return true;

            default:
                return false;
        }
    }

    private void setValues()
    {
        _transactionData.setData(_receivedArgs[1], _receivedArgs[2], _receivedArgs[3]);
    }
}