using System.Collections.Generic;

namespace CEM.Util;

public class ConsoleRequestHandler
{
    private string[] _receivedArgs;
    private ITransactionData _transactionData;
    private RequestType requestType = RequestType.Invalid;

    public ConsoleRequestHandler(string[] args)
    {
        _receivedArgs = args;
        _transactionData = new TransactionData();
    }

    public RequestType getRequestType()
    {
        processRequest();
        return requestType;
    }

    private void processRequest()
    {
        if (ArgumentsOK() && RequestOK())
        {
            setValues();
        }
    }

    private bool ArgumentsOK()
    {
        bool invalidArguments = _receivedArgs.Length != 4;

        if (invalidArguments)
        {
            //Console.WriteLine($"Missing argument: --type <category> <description> <value>");
            return false;
        }
        return true;
    }

    private bool RequestOK()
    {
        switch (_receivedArgs[0])
        {
            case "--expense":
                requestType = RequestType.Expense;
                return true;
    
            case "--income":
                requestType = RequestType.Income;
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