using System;
namespace CEM.Util;

public enum RequestType{
    Expense,
    Income,
    Report,
    Invalid,
}

public class ConsoleRequestHandler
{
    string[] args;

    string category = "";
    string description = "";
    float value = 0;
    RequestType requestType = RequestType.Invalid;


    public ConsoleRequestHandler(string[] _args)
    {
        args = _args;
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
        bool invalidArguments = args.Length != 4;
        if (invalidArguments)
        {
            //Console.WriteLine($"Missing argument: --type <category> <description> <value>");
            return false;
        }
        return true;
    }

    private bool RequestOK()
    {
        switch (args[0])
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
        category = args[1];
        description = args[2];
        value = float.Parse(args[3]); 
    }

}