using CEM.Util;
using CemApi.Util;
using CemApi.DTOs;

var requestHandler = new ConsoleRequestHandler(args);
var cemanager = new ClientCEM();

requestHandler.ValidateRequest();
ITransactionData transactionData = requestHandler.GetTransactionData();

bool validRequest = transactionData.GetRequestType() != RequestType.Invalid;
bool notReport = transactionData.GetRequestType() != RequestType.Report;

if (validRequest & notReport)
{
    cemanager.MakeTransaction(transactionData);
}
else
{
    cemanager.ShowMonthlyReport();
}



