using CEM.Util;
using CemApi.Util;
using CemApi.DTOs;

var requestHandler = new ConsoleRequestHandler(args);

requestHandler.ValidateRequest();
ITransactionData transactionData = requestHandler.GetTransactionData();

bool validRequest = transactionData.GetRequestType() != RequestType.Invalid;
bool notReport = transactionData.GetRequestType() != RequestType.Report;

if (validRequest & notReport)
{
    await ClientCEM.MakeTransaction(transactionData);
}
else
{
    await ClientCEM.ShowMonthlyReport();
}



