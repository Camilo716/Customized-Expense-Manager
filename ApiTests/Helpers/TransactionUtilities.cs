using System.Text;
using CemApi.DTOs;
using CemApi.Util;
using Newtonsoft.Json;

namespace IntegrationTests.Helpers;

public static class TransactionUtilities
{
    internal static HttpContent GetTransactionHttpContent(TransactionDTO transactionDTO)
    {
        string jsonContent = JsonConvert.SerializeObject(transactionDTO);

        HttpContent httpContent = new StringContent(
            jsonContent, Encoding.UTF8, "application/json");
        return httpContent;
    }
}