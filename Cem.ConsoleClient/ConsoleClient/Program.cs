using CEM.Util;
using CemApi.DTOs;
using Cem.Api.Common;

var requestHandler = new ConsoleRequestHandler(args);

requestHandler.ValidateRequest();
ITransactionData transactionData = requestHandler.GetTransactionData();

bool validRequest = transactionData.GetRequestType() != TransactionType.Invalid;
bool notReport = transactionData.GetRequestType() != TransactionType.Report;

if (validRequest & notReport)
{
    await ClientCEM.MakeTransaction(transactionData);
}
else
{
    await ClientCEM.ShowMonthlyReport();
}



