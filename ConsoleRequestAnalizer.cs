using System;

namespace CEM.Util;

public enum RequestType{
    Expense,
    Income,
    Report,
}

public class ConsoleRequestHandler
{
    string[] args;

    string category = "";
    string description = "";
    float value = 0;
    RequestType requestType;


    public ConsoleRequestHandler(string[] _args)
    {
        args = _args;
    }

    public RequestType getRequestType()
    {
        checkIfIsExpense();
        return requestType;
    }

    public void checkIfIsExpense()
    {
        if (args[0] == "--expense")
        {
            requestType = RequestType.Expense;
            setValues();
            validateRequest("expense");
        }
    }

    private void setValues()
    {
        category = args[1];
        description = args[2];
        value = float.Parse(args[3]); 
    }

    private void validateRequest(string type)
    {
        bool missArguments = string.IsNullOrEmpty(category) || string.IsNullOrEmpty(description) || value == 0;
        if (missArguments)
        {
            Console.WriteLine($"Missing argument: --{type} <category> <description> <value>");
        }
    }
}