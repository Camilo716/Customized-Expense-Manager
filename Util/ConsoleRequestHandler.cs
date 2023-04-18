using System.Collections.Generic;

namespace CEM.Util;

public class ConsoleRequestHandler
{
    private string[] receivedArgs;
    private Dictionary<string, string> transactionData = new Dictionary<string, string>()
    {
        {"category", ""},{"description", ""},{"value", ""},
    };
    private RequestType requestType = RequestType.Invalid;

    public ConsoleRequestHandler(string[] _args)
    {
        receivedArgs = _args;
    }

    public RequestType getRequestType()
    {
        processRequest();
        return requestType;
    }

    public Dictionary<string,string> getTransactionData()
    {
        return transactionData;
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
        bool invalidArguments = receivedArgs.Length != 4;

        if (invalidArguments)
        {
            //Console.WriteLine($"Missing argument: --type <category> <description> <value>");
            return false;
        }
        return true;
    }

    private bool RequestOK()
    {
        switch (receivedArgs[0])
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
        transactionData["category"] = receivedArgs[1];
        transactionData["description"] = receivedArgs[2];
        transactionData["value"] = receivedArgs[3]; 
    }

}