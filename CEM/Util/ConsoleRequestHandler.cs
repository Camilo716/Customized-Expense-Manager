using CemApi.Util;

namespace CEM.Util;

public class ConsoleRequestHandler
{
    private readonly string[] _receivedArgs;
    private ITransactionData _transactionData;
    private RequestType _requestTypeUnchecked;

    public ConsoleRequestHandler(string[] args)
    {
        _receivedArgs = args;
        _transactionData = new TransactionData();
    }

    public ITransactionData GetTransactionData()
    {
        return _transactionData;
    }

    public void ValidateRequest()
    {
        if (RequestOK() & ArgumentsOK())
        {
            ProccessAcceptedRequest();
        }
    }

    private void ProccessAcceptedRequest()
    {
        _transactionData.SetRequestType(_requestTypeUnchecked);

        if (!RequestIsReport())
        {
            SetTransactionValues();
        }
    }

    private bool RequestOK()
    {
        switch (_receivedArgs[0])
        {
            case "--expense":
                _requestTypeUnchecked = RequestType.Expense;
                return true;
    
            case "--income":
                _requestTypeUnchecked = RequestType.Income;
                return true;

            case "--report":
                _requestTypeUnchecked = RequestType.Report;
                return true;
            default:
                _requestTypeUnchecked = RequestType.Invalid;
                return false;
        }
    }

    private bool ArgumentsOK()
    {
        if (!RequestIsReport()) 
            return _receivedArgs.Length == 4;

        else 
            return _receivedArgs.Length == 1;
    }

    private bool RequestIsReport()
    {
        return _requestTypeUnchecked == RequestType.Report;
    }

    private void SetTransactionValues()
    {
        _transactionData.SetData(_receivedArgs[1], _receivedArgs[2], _receivedArgs[3]);
    }
}